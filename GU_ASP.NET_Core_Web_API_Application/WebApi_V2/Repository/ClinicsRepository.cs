using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public class ClinicsRepository : IClinicsRepository
    { 
        private readonly ApplicationDataContext _context;

        public ClinicsRepository(ApplicationDataContext context) => _context = context;

        public async Task Add(Clinic clinic)
        {
            _context.Clinics.Add(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var clinicDelete = await _context.Clinics.SingleOrDefaultAsync(t => t.Id == id);
            if (clinicDelete is null) return;
            _context.Clinics.Remove(clinicDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Clinic>> Get()
        {
            return await _context.Clinics.ToListAsync();
        }

        public async Task Update(Clinic clinic)
        {
            _context.Clinics.Update(clinic);
            await _context.SaveChangesAsync();
        }

        public async Task AddCatInClinic(int clinicId, int catId)
        {
            var clinic = await _context.Clinics.Include(c => c.Cats).SingleOrDefaultAsync(t => t.Id == clinicId);
            var cat = await _context.Cats.SingleOrDefaultAsync(t => t.Id == catId);

            if (clinic is null || cat is null || clinic.Cats.Contains(cat)) return;

            clinic.Cats.Add(cat);

            await _context.SaveChangesAsync();
        }

        public async Task<IList<Cat>> GetListCatInClinic(int clinicId)
        {
            var clinic = await _context.Clinics.Include(c => c.Cats).SingleOrDefaultAsync(t => t.Id == clinicId);
            return clinic is null ? new List<Cat>() : clinic.Cats.ToList();
        }
    }
}
