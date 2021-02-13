using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace WTHRstat.APP.Models
{
    public class EmissionERD
    {
        public int Id { get; set; }
        public int Source_Id { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }

        public SourceERD Source { get; set; }
    }
}