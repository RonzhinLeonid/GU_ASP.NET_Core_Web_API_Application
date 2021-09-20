using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface IClinicsRepository
    {
        Task Add(Clinic cat);

        Task<IList<Clinic>> Get();

        Task Delete(int id);

        Task Update(Clinic cat);

        //Task<IList<Clinic>> GetFilterName(SearchWithPageRequest searchWithPage);
        //Task<IList<Clinic>> GetFilterName(SearcRequest search);
    }
}
