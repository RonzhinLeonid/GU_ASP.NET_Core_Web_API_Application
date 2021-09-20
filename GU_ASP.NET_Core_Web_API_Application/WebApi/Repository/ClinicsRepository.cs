using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public class ClinicsRepository : IClinicsRepository
    {
        private readonly IDbContextFactory<ApplicationDataContext> _context;

        public ClinicsRepository(IDbContextFactory<ApplicationDataContext> context) => _context = context;

        public async Task Add(Clinic clinic)
        {
            await using var clinicsList = _context.CreateDbContext();
            await clinicsList.AddAsync(clinic);
            await clinicsList.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await using var clinicsList = _context.CreateDbContext();
            var clinicDelete = await clinicsList.Clinics.SingleOrDefaultAsync(t => t.Id == id);
            if (clinicDelete is null) return;
            clinicsList.Clinics.Remove(clinicDelete);
            await clinicsList.SaveChangesAsync();
        }

        public async Task<IList<Clinic>> Get()
        {
            await using var clinicsList = _context.CreateDbContext();
            return await clinicsList.Clinics.ToListAsync();
        }

        public async Task Update(Clinic clinic)
        {
            await using var clinicsList = _context.CreateDbContext();
            clinicsList.Update(clinic);
            await clinicsList.SaveChangesAsync();
        }
    }
}
