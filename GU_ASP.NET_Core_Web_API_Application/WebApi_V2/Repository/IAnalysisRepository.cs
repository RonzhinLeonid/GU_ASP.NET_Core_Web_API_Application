using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public interface IAnalysisRepository
    {
        Task AssignAnalysisToCat(Analysis analysis, int catId, int clinicId );
    }
}
