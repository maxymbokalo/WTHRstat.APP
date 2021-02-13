using System.ComponentModel.DataAnnotations;

namespace WTHRstat.APP.Models
{
    public class SourceERD
    {
        public int Id { get; set; }
        public int Emission_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public EmissionERD Emission { get; set; }
    }
}