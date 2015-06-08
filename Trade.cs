using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace PetrMacek.ResultsImport
{
    public class Trade
    {
        [CsvField(Name = "Trade-#")]
        public string Number { get; set; }

        [CsvField(Name = "Instrument")]
        public string Instrument { get; set; }

        [CsvField(Name = "Account")]
        public string Account { get; set; }

        [CsvField(Name = "Strategy")]
        public string Strategy { get; set; }

        [CsvField(Name = "Market pos.")]
        public string MarketPosition { get; set; }

        [CsvField(Name = "Quantity")]
        public int Quantity { get; set; }

        [CsvField(Name = "Entry price")]
        public string EntryPrice { get; set; }

        [CsvField(Name = "Exit price")]
        public string ExitPrice { get; set; }

        [CsvField(Name = "Entry time")]        
        public string EntryTime { get; set; }

        [CsvField(Name = "Exit time")]
        public string ExitTime { get; set; }

        [CsvField(Name = "Entry name")]
        public string EntryName { get; set; }
        
        [CsvField(Name = "Profit")]
        public string Profit { get; set; }

        [CsvField(Name = "Cum. profit")]
        public string CummulativeProfit { get; set; }

        [CsvField(Name = "Commission")]
        public string Commission { get; set; }

        [CsvField(Name = "MAE")]
        public string MAE { get; set; }

        [CsvField(Name = "MFE")]
        public string MFE { get; set; }

        [CsvField(Name = "ETD")]
        public string ETD { get; set; }

        [CsvField(Name = "Bars")]
        public int Bars { get; set; }

    }
}
