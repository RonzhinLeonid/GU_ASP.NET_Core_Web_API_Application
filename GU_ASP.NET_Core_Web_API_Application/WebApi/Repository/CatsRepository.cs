using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public class CatsRepository : ICatsRepository
    {
        private readonly ApplicationDataContext _context;

        public CatsRepository(ApplicationDataContext context)
        {
            _context = context;
        }

        public void Add(Cat kitten)
        {
            throw new NotImplementedException();
        }

        public IList<Cat> Get()
        {
            throw new NotImplementedException();
        }
    }
}