using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface ICatsRepository
    {
        Task Add(Cat cat);

        Task<IList<Cat>> Get();

        Task Delete(int id);

        Task Update(Cat cat);

        Task<IList<Cat>> GetFilter(string nickname, int page, int size);
    }
}