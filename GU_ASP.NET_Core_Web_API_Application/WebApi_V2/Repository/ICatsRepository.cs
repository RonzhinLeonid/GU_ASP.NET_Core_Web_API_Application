using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;

namespace WebApi_V2.Repository
{
    public interface ICatsRepository
    {
        Task Add(Cat cat);
        Task<IList<Cat>> Get();
        Task Delete(int id);
        Task Update(Cat cat);
        Task<IList<Cat>> GetFilterName(SearchWithPageRequest searchWithPage);
        Task<IList<Cat>> GetFilterName(SearcRequest search);
    }
}
