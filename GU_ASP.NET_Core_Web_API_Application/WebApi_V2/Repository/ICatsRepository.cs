using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public interface ICatsRepository
    {
        void Add(Cat kitten);
        IList<Cat> Get();
    }
}
