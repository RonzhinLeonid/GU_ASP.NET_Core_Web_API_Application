using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface ICatsRepository
    {
        void Add(Cat kitten);

        IList<Cat> Get();
    }
}