using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Globalization;

namespace PetrMacek.ResultsImport
{
    public enum DataFormat {
     Points, Percentage, Currency
    }

    enum TradesHandling
    {
        Discretional, Automated
    }
    
    public partial class ImportForm : Form
    {
        private List<Trade> tradesList;
        private DataFormat dataFormat = DataFormat.Points;
        private CultureInfo culture = new CultureInfo("en-US");
        private string csvDelimiter = ",";
        private string journalFileName;
        private TradesHandling tradesHandling = TradesHandling.Discretional;
        private InstrumentsRepository instRep;

        public ImportForm()
        {
            InitializeComponent();
            pnlOutputfile.Hide();
            try
            {
                instRep = new InstrumentsRepository();
            }
            catch (CannotLoadInstrumentsException cne)
            {
                MessageBox.Show(cne.Message);

            }
        }


        private void openFile_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "csv files (*.csv)|*.csv";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fStream = File.Open(openFile.FileName, FileMode.OpenOrCreate))
                    {
                        var csv = new CsvHelper.CsvHelper(fStream);
                        csv.Configuration.Delimiter = csvDelimiter.ToCharArray(0,1)[0];
                        csv.Configuration.UseInvariantCulture = true;
                        tbFilePath.Text = openFile.FileName;
                        tradesList = csv.Reader.GetRecords<Trade>().ToList();
                        if (tradesList != null && tradesList.Count > 0)
                        {
                            btnImport.Enabled = true;
                            lblTradesCount.Text = tradesList.Count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    tbFilePath.Text = string.Empty;
                    MessageBox.Show("Error: Could not read file from disk. The file could be malformed or the delimiter is not properly defined. Original error: " + ex.Message);
                }
            }
        }

        private ExcelPackage openExcel(string file)
        {
            FileInfo newFile = new FileInfo(file);
            return new ExcelPackage(newFile);
        }

        private ExcelPackage openExcel(Stream stream)
        {
            return new ExcelPackage(stream);
        }

        private Dictionary<DateTime, List<Trade>> groupTradesByDate()
        {
            Dictionary<DateTime, List<Trade>> dict = new Dictionary<DateTime,List<Trade>>();
            foreach(Trade t in tradesList){
                DateTime entryTime = DateTime.Parse(t.EntryTime, culture);
                if (!dict.ContainsKey(entryTime))
                {
                    dict.Add(entryTime, new List<Trade>() { t });
                }
                else
                {
                    dict[entryTime].Add(t);
                }
            }
            return dict;
        }


        public System.IO.Stream loadEmbeddedExcel()
        {
            //            
            var assembly = Assembly.GetExecutingAssembly();
            System.IO.Stream stream = assembly.GetManifestResourceStream("PetrMacek.ResultsImport.Resources.Journal2.3beta18.xlsm");
            try
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Couldnot find embedded mappings resource file.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stream;
        }


        private string getMILTime(DateTime time)
        {
            return time.ToString("HHmm");
        }

        private int getFirstFreeRow(ExcelWorksheet ws)
        {
            for (int i = 2; i < 20000; i++)
            {
                var cell = ws.Cells["B" + i].Value;
                if (cell == null)
                {
                    return i-1;
                }
            }

            throw new ArgumentException("Cannot find the place to start appending.");
        }

        private double parseDouble(string value)
        {
            return Double.Parse(value, culture.NumberFormat);
        }


        private int calculateMFE(string instrumentCode, string mfe, string commission, int contracts)
        {
            try {
                Instrument instrument = instRep.GetInstrument(instrumentCode);
                return instrument.GetTicks(dataFormat, parseDouble(mfe) - parseDouble(commission), contracts);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        private int calculateMAE(string instrumentCode, string mae, string commission, int contracts)
        {
            try
            {
                Instrument instrument = instRep.GetInstrument(instrumentCode);
                return instrument.GetTicks(dataFormat, parseDouble(mae) - parseDouble(commission), contracts);
            }
            catch (ArgumentException e)
            {
                throw e;
            }
        }

        private void writeLastLineWrittenTo(ExcelPackage pck, int lineNumber)
        {
            var ws = pck.Workbook.Worksheets["Internal Calcs"];
            if (ws == null)
            {
                return;
            }
            ws.Cells["P38"].Value = lineNumber;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //FileInfo newFile = new FileInfo(@"c:\DVD\Journal2.xlsm");
            ExcelPackage pck = null;

            try
            {
                //pck = new ExcelPackage(newFile);
                if (rbNewFile.Checked)
                {
                    pck = new ExcelPackage(loadEmbeddedExcel());
                }
                else if (rbAppend.Checked)
                {
                    pck = openExcel(journalFileName);
                }
                var ws = pck.Workbook.Worksheets["Journal"];

                if (ws == null)
                {
                    return;
                }
                int row = 2;
                if (rbAppend.Checked)
                {
                    row = getFirstFreeRow(ws);
                }
                DateTime lastTime = DateTime.MinValue;
                var tradesByDate = groupTradesByDate();

                foreach (var date in tradesByDate.Keys)
                {
                    int tradeNo = 0;
                    List<Trade> cars = tradesByDate[date];
                    row++;

                    foreach (Trade trade in cars)
                    {
                        tradeNo++;
                        DateTime entryTime = DateTime.Parse(trade.EntryTime, culture);
                        DateTime exitTime = DateTime.Parse(trade.ExitTime, culture);


                        if (tradeNo == 2)
                        {
                            ws.Cells["J" + row].Value = Double.Parse(trade.ExitPrice);
                            ws.Cells["J" + row].Style.Numberformat.Format = "#,00";
                            ws.Cells["K" + row].Value = trade.Quantity;



                            double mfe = calculateMFE(trade.Instrument, trade.MFE, trade.Commission, trade.Quantity);
                            double mae = calculateMAE(trade.Instrument, trade.MAE, trade.Commission, trade.Quantity);

                            if ((double)ws.Cells["U" + row].Value < mfe)
                            {
                                ws.Cells["U" + row].Value = mfe;
                                ws.Cells["V" + row].Value = mfe;
                            }
                            ws.Cells["Q" + row].Value = mae;


                            ws.Cells["AA" + row].Value = (exitTime - entryTime).Minutes;
                            continue;
                        }

                        if (tradeNo == 3)
                        {
                            ws.Cells["L" + row].Value = Double.Parse(trade.ExitPrice);
                            ws.Cells["L" + row].Style.Numberformat.Format = "#,00";
                            ws.Cells["M" + row].Value = trade.Quantity;

                            double mfe = calculateMFE(trade.Instrument, trade.MFE, trade.Commission, trade.Quantity);
                            double mae = calculateMAE(trade.Instrument, trade.MAE, trade.Commission, trade.Quantity);

                            if ((double)ws.Cells["U" + row].Value < mfe)
                            {
                                ws.Cells["U" + row].Value = mfe;
                                ws.Cells["V" + row].Value = mfe;
                            }
                            ws.Cells["R" + row].Value = mae;


                            ws.Cells["AB" + row].Value = (exitTime - entryTime).Minutes;
                            continue;
                        }

                        ws.Cells["B" + row].Value = entryTime.ToString("d", culture);
                        ws.Cells["C" + row].Value = getMILTime(entryTime);//entryTime.ToString("t", culture);
                        if (tradesHandling == TradesHandling.Automated)
                            ws.Cells["D" + row].Value = trade.EntryName;
                        ws.Cells["E" + row].Value = trade.Instrument.Split(' ')[0];
                        ws.Cells["F" + row].Value = trade.MarketPosition;
                        ws.Cells["G" + row].Value = Double.Parse(trade.EntryPrice);
                        ws.Cells["G" + row].Style.Numberformat.Format = "#,00";
                        ws.Cells["H" + row].Value = Double.Parse(trade.ExitPrice);
                        ws.Cells["H" + row].Style.Numberformat.Format = "#,00";
                        ws.Cells["I" + row].Value = trade.Quantity;

                        /*
                        ws.Cells["J" + row].Value = string.Empty;
                        ws.Cells["K" + row].Value = string.Empty;
                        ws.Cells["L" + row].Value = string.Empty;
                        ws.Cells["M" + row].Value = string.Empty;
                        ws.Cells["N" + row].Value = string.Empty;
                        ws.Cells["Q" + row].Value = string.Empty;
                        ws.Cells["R" + row].Value = string.Empty;
                        */
                        double mfe1 = calculateMFE(trade.Instrument, trade.MFE, trade.Commission, trade.Quantity);
                        double mae1 = calculateMAE(trade.Instrument, trade.MAE, trade.Commission, trade.Quantity);

                        ws.Cells["P" + row].Value = mae1;
                        ws.Cells["U" + row].Value = mfe1 == 0 ? 1 : mfe1;
                        ws.Cells["V" + row].Value = mfe1 == 0 ? 1 : mfe1;

                        ws.Cells["Z" + row].Value = (exitTime - entryTime).Minutes;

                        ws.Cells["AE" + row].Value = 8;
                        if (tradesHandling == TradesHandling.Automated)
                            ws.Cells["AG" + row].Value = "Followed Rules";
                    }

                }


                    writeLastLineWrittenTo(pck, row);
                

            

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Microsoft Excel|*.xlsm";
                    saveFileDialog1.Title = "Save the resulting file";
                    saveFileDialog1.ShowDialog();

                    // If the file name is not an empty string open it for saving.
                    if (saveFileDialog1.FileName != "")
                    {

                        pck.SaveAs(new FileInfo(saveFileDialog1.FileName));

                    }
                    MessageBox.Show("Import finished");
                }
            
            catch (Exception excep)
            {
                MessageBox.Show(string.Format("Oops, something bad happened when loading the CSV: {0}", excep.Message));
            }
            finally
            {
                if (pck != null)
                {
                    pck.Dispose();
                }
            }

        }


        private int convertTime(string time)
        {
            string minutes = time.Substring(0, 5);
            string intValue = minutes.Replace(":", "");
            return int.Parse(intValue);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataFormat = DataFormat.Points;
        }

        private void rdPercent_CheckedChanged(object sender, EventArgs e)
        {
            dataFormat = DataFormat.Percentage;
        }

        private void rdCurrency_CheckedChanged(object sender, EventArgs e)
        {
            dataFormat = DataFormat.Currency;
        }

        private void rbLocaleUs_CheckedChanged(object sender, EventArgs e)
        {
            culture = new CultureInfo("en-US", false);
        }

        private void rbLocaleCz_CheckedChanged(object sender, EventArgs e)
        {
            culture = new CultureInfo("cs-CZ", false);
        }

        private void tbCsvDelimiter_TextChanged(object sender, EventArgs e)
        {
            csvDelimiter = tbCsvDelimiter.Text;
        }

        private void rbAppend_CheckedChanged(object sender, EventArgs e)
        {
            pnlOutputfile.Show();
        }

        private void rbNewFile_CheckedChanged(object sender, EventArgs e)
        {
            pnlOutputfile.Hide();
        }

        private void btnOpenJournal_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog();
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "Excel files (*.xlsm)|*.xlsm";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                journalFileName = openFile.FileName;
                tbOutputFilePath.Text = journalFileName;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void rbHandlingDiscretionary_CheckedChanged(object sender, EventArgs e)
        {
            tradesHandling = TradesHandling.Discretional;
        }

        private void rbHandlingAuto_CheckedChanged(object sender, EventArgs e)
        {
            tradesHandling = TradesHandling.Automated;
        }

       
   

    }
}
