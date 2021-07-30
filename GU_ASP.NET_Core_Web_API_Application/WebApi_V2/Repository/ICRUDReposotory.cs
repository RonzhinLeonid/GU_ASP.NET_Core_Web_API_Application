using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public interface ICRUDReposotory<TEntity>
    { 
        Task Add(TEntity cat);
        Task<IList<TEntity>> Get();
        Task Delete(int id);
        Task Update(TEntity cat);
    }
}
