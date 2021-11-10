using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WTHRstat.APP.ModelsERD
{
    public class DailyAqiERD
    {
        public string SourceName {get;set;}
        public DateTime Date { get; set; }
        public double Aqi { get; set; }
    }
}
