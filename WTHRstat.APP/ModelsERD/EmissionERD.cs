using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace WTHRstat.APP.Models
{
    public class EmissionERD
    {
        public int Id { get; set; }
        public string Pollutant { get; set; }
        public int Concentration { get; set; }
        public string Units { get; set; }
        public DateTime Date { get; set; }
        public int Source_Id { get; set; }

        public SourceERD Source { get; set; }
    }
}