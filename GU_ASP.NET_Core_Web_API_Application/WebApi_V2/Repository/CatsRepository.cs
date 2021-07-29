using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly ApplicationDataContext _context;

        public CatsRepository(ApplicationDataContext context) => _context = context;

        public void Add(Cat cat)
        {
            _context.Set<Cat>().Add(cat);
            _context.SaveChanges();
        }

        public IList<Cat> Get()
        {
            return _context.Set<Cat>().ToList();
        }
    }
}
