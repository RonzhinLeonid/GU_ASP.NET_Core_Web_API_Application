using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDataContext _context;
        public AnalysisRepository(ApplicationDataContext context) => _context = context;

        public async Task AssignAnalysisToCat(Analysis analysis, int catId, int clinicId)
        {
            var cat = await _context.Cats.Include(c => c.Clinics).SingleOrDefaultAsync(t => t.Id == catId);
            var clinic = await _context.Clinics.SingleOrDefaultAsync(t => t.Id == clinicId);
            if (clinic is null || cat is null) return;

            if (cat.Clinics.All(c => c.Id != clinicId))
            {
                cat.Clinics.Add(clinic);
            }

            analysis.Clinic = clinic;
            analysis.Patient = cat;

            await _context.Analysis.AddAsync(analysis);
            await _context.SaveChangesAsync();
        }
    }
}
