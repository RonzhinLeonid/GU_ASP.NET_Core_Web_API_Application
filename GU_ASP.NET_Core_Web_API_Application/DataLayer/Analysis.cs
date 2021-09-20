using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Analysis
    {
        public int Id { get; init; }
        public DateTime dateOfAnalysis { get; set; }
        public string Name { get; init; }
        public bool Paid { get; init; }
        public string Result { get; init; }
        public Cat Patient { get; set; }
        public Clinic Clinic { get; set; }
    }
}
