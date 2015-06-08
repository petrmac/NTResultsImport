using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PetrMacek.ResultsImport
{
    public class CannotLoadInstrumentsException : Exception
    {
        public CannotLoadInstrumentsException(string message)
            : base(message)
        {

        }
    }

    public class InstrumentsRepository
    {
        private Dictionary<string, Instrument> instrumentsMap;

        public InstrumentsRepository()
        {
            instrumentsMap = new Dictionary<string, Instrument>();
            List<Instrument> list = loadInstruments();
            foreach (Instrument i in list)
            {
                instrumentsMap.Add(i.Code, i);
            }
        }

        public Instrument GetInstrument(string code)
        {
            if (code == null)
            {
                throw new ArgumentException("Instrument code cannot be empty");
            }
            if (code.IndexOf(' ') > 0)
            {
                code = code.Split(' ')[0];
            }
            if (!instrumentsMap.Keys.Contains(code))
            {
                throw new ArgumentException(string.Format("The instrument you are trying to load ({0}) is not available. Please modify the instrument-list.txt accordingly.", code));
            }

            return instrumentsMap[code];
        }

        public List<Instrument> loadInstruments()
        {
            List<Instrument> instruments;
            try
            {
                using (FileStream fStream = File.Open("instrument-list.txt", FileMode.OpenOrCreate))
                {
                    var csv = new CsvHelper.CsvHelper(fStream);
                    csv.Configuration.Delimiter = ';';
                    csv.Configuration.UseInvariantCulture = true;
                    instruments = csv.Reader.GetRecords<Instrument>().ToList();
                }
                return instruments;
            }
            catch (Exception e)
            {
                throw new CannotLoadInstrumentsException(string.Format("There is some problem starting application. Cannot load the instrumet list: {0}", e.Message));
            }
        }
    }
}
