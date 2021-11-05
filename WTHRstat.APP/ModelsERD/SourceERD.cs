using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WTHRstat.APP.Models
{
    public class SourceERD
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public List<EmissionERD> Emissions { get; set; }
    }
}