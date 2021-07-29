using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly IDbContextFactory<ApplicationDataContext> _context;

        public CatsRepository(IDbContextFactory<ApplicationDataContext> context) => _context = context;

        public void Add(Cat cat)
        {
            var catsList = _context.CreateDbContext();
            catsList.Add(cat);
            catsList.SaveChanges();
        }

        public IList<Cat> Get()
        {
            var catsList = _context.CreateDbContext();
            return catsList.Cats.ToList();
        }
    }
}