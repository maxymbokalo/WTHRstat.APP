using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WTHRstat.APP.ModelsERD
{
    public class AqiERD
    {
        public int SourceId { get; set; }
        public List<DailyAqiERD> SourceAqisList { get; set; }
    }
}
