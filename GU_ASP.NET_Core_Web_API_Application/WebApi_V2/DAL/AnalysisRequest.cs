using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.DAL
{
    public class AnalysisRequest
    {
        public DateTime dateOfAnalysis { get; set; }
        public string Name { get; init; }
        public bool Paid { get; init; }
        public string Result { get; init; }
    }
}
