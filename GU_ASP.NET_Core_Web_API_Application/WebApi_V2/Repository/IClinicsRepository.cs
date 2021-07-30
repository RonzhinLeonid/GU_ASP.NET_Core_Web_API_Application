using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_V2.Repository
{
    public interface IClinicsRepository : ICRUDReposotory<Clinic>
    { 
        Task AddCatInClinic(int clinicId, int catId);
        Task<IList<Cat>> GetListCatInClinic(int clinicId);
    }
}
