using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;

namespace WebApi_V2.Controllers
{
    [Route("cats")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly ICatsRepository _catsRepository;
        private readonly IMapper _mapper;

        public CatController(ICatsRepository catsRepository, IMapper mapper)
        {
            _catsRepository = catsRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task Add(CatRequest request) 
        {
            await _catsRepository.Add(_mapper.Map<Cat>(request));
        }

        [HttpGet]
        public async Task<IEnumerable<CatResponses>> Get()
        {
            var data = await _catsRepository.Get();
            return data.Select(_mapper.Map<CatResponses>);
        }

        [HttpDelete("{id:int}")]
        public async Task DeleteAsync([FromRoute] int id)
        {
            await _catsRepository.Delete(id);
        }

        [HttpPut]
        public async Task UpdateAsync(CatUpdRequest request)
        {
            await _catsRepository.Update(_mapper.Map<Cat>(request));
        }

        [HttpGet("searchFilter")]
        public async Task<IEnumerable<CatResponses>> GetWithFilter([FromQuery] SearchCatWithPageRequest searchWithPage)
        {
            var data = await _catsRepository.GetFilterName(searchWithPage);
            return data.Select(_mapper.Map<CatResponses>);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<CatResponses>> GetWithFilter([FromQuery] SearchCatRequest search)
        {
            var data = await _catsRepository.GetFilterName(search);
            return data.Select(_mapper.Map<CatResponses>);
        }

        [HttpPost("{catId:int}/add/{clinicId:int}")]
        public async Task AddCatInClinic(int catId, int clinicId)
        {
            await _catsRepository.AddClinicInCat(catId, clinicId);
        }

        [HttpGet("{catId:int}")]
        public async Task<IEnumerable<ClinicResponses>> GetListClinicsInCat(int catId)
        {
            var data = await _catsRepository.GetListClinicsInCat(catId);
            return data.Select(_mapper.Map<ClinicResponses>);
        }
    }
}
