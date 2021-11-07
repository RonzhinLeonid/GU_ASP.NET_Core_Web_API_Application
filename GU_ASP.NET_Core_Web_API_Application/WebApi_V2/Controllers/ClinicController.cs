using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;

namespace WebApi_V2.Controllers
{ 
    [Route("clinics")]
    [ApiController]
    [Authorize]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicsRepository _clinicsRepository;
        private readonly IMapper _mapper;

        public ClinicController(IClinicsRepository clinicsRepository, IMapper mapper)
        {
            _clinicsRepository = clinicsRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task Add(ClinicRequest request)
        {
            await _clinicsRepository.Add(_mapper.Map<Clinic>(request));
        }

        [HttpGet]
        public async Task<IEnumerable<ClinicResponses>> Get()
        {
            var data = await _clinicsRepository.Get();
            return data.Select(_mapper.Map<ClinicResponses>);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _clinicsRepository.Delete(id);
        }

        [HttpPut]
        public async Task UpdateAsync(ClinicUpdRequest request)
        {
            await _clinicsRepository.Update(_mapper.Map<Clinic>(request));
        }

        [HttpPost("{clinicId:int}/add/{catId:int}")]
        public async Task AddCatInClinic(int clinicId, int catId)
        {
            await _clinicsRepository.AddCatInClinic(clinicId, catId);
        }

        [HttpGet("{clinicId:int}")]
        public async Task<IEnumerable<CatResponses>> GetListClinicsInCat(int clinicId)
        {
            var data = await _clinicsRepository.GetListCatInClinic(clinicId);
            return data.Select(_mapper.Map<CatResponses>);
        }
    }
}
