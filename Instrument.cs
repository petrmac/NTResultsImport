using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper.Configuration;

namespace PetrMacek.ResultsImport
{

    public class Instrument
    {
        [CsvField(Name = "Code")]
        public string Code { get; set; }

        [CsvField(Name = "Name")]
        public string Name { get; set; }

        [CsvField(Name = "Point value")]
        public double PointValue { get; set; }

        [CsvField(Name = "Tick value")]
        public double TickValue { get; set; }

        [CsvField(Name = "Tick size")]
        public double TickSize { get; set; }

        /// <summary>
        /// Calculates the ticks count based on the given amount in money
        /// </summary>
        /// <param name="value">amount in money or points or percentage</param>
        /// <param name="format">format of the value</param>
        /// <returns>number of ticks</returns>
        public int GetTicks(DataFormat format, double value)
        {
            switch (format){
            case DataFormat.Currency:
                return (int)(value / PointValue / TickSize);
            case DataFormat.Points:
                return (int)(value / TickValue);
            }
            throw new ArgumentException("Percentage is not supported yet");
        }

        /// <summary>
        /// Calculates the ticks count per contract based on the given amount in money and contracts count
        /// </summary>
        /// <param name="value">amount in money</param>
        /// <param name="numberOfContracts">contracts</param>
        /// <returns></returns>
        public int GetTicks(DataFormat format, double value, int numberOfContracts)
        {
            return (int)(GetTicks(format, value) / numberOfContracts);
        }
    }
}
