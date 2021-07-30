using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;

namespace WebApi_V2.Repository
{
    public interface ICatsRepository : ICRUDReposotory<Cat> 
    {
        Task<IList<Cat>> GetFilterName(SearchCatWithPageRequest searchWithPage);
        Task<IList<Cat>> GetFilterName(SearchCatRequest search);
        Task AddClinicInCat(int catId, int clinicId);
        Task<IList<Clinic>> GetListClinicsInCat(int catId);
    }
}
