using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL;

namespace WebApi.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly IDbContextFactory<ApplicationDataContext> _context;

        public CatsRepository(IDbContextFactory<ApplicationDataContext> context) => _context = context;

        public async Task Add(Cat cat)
        {
            await using var catsList = _context.CreateDbContext();
            await catsList.AddAsync(cat);
            await catsList.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await using var catsList = _context.CreateDbContext();
            var catDelete = await catsList.Cats.SingleOrDefaultAsync(t => t.Id == id);
            if (catDelete is null) return;
            catsList.Cats.Remove(catDelete);
            await catsList.SaveChangesAsync();
        }

        public async Task<IList<Cat>> Get()
        {
            await using var catsList = _context.CreateDbContext();
            return await catsList.Cats.ToListAsync();
        }
        public async Task Update(Cat cat)
        {
            await using var catsList = _context.CreateDbContext();
            catsList.Update(cat);
            await catsList.SaveChangesAsync();
        }

        public async Task<IList<Cat>> GetFilterName(SearchWithPageRequest searchWithPage)
        {
            if (searchWithPage.Page < 1) return new List<Cat>();
            await using var catsList = _context.CreateDbContext();
            return await catsList.Cats
                .Where(p => p.Nickname.ToLower().Contains(searchWithPage.Nickname.ToLower()))
                .Skip((searchWithPage.Page-1) * searchWithPage.Size)
                .Take(searchWithPage.Size)
                .ToListAsync();
        }
        public async Task<IList<Cat>> GetFilterName(SearcRequest search)
        {
            await using var catsList = _context.CreateDbContext();
            return await catsList.Cats
                .Where(p => p.Nickname.ToLower().Contains(search.Nickname.ToLower()))
                .ToListAsync();
        }
    }
}