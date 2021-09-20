using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_V2.DAL;
using WebApi_V2.Repository;
using WebApi_V2.Validations;

namespace WebApi_V2.Controllers
{
    [Route("cats")]
    [ApiController]
    [Authorize]
    public class CatController : ControllerBase
    {
        private readonly ICatsRepository _catsRepository;
        private readonly IMapper _mapper;
        private readonly ICatCreateValidation _createRequestValidator;
        private readonly ICatUpdateValidation _updateRequestValidator;

        public CatController(ICatsRepository catsRepository, IMapper mapper, ICatCreateValidation createRequestValidator , ICatUpdateValidation updateRequestValidator)
        {
            _catsRepository = catsRepository;
            _mapper = mapper;
            _createRequestValidator = createRequestValidator;
            _updateRequestValidator = updateRequestValidator;
        }

        [HttpPost]
        public async Task<CatCreateResponse> Add(CatRequest request)
        {
            var failures = _createRequestValidator.ValidateEntity(request);
            if (failures.Count > 0)
            {
                return new CatCreateResponse(failures, false);
            }
            await _catsRepository.Add(_mapper.Map<Cat>(request));
            return new CatCreateResponse(failures, true);
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
        public async Task<CatUpdateResponse> UpdateAsync(CatUpdRequest request)
        {
            var failures = _updateRequestValidator.ValidateEntity(request);
            if (failures.Count > 0)
            {
                return new CatUpdateResponse(failures, false);
            }
            await _catsRepository.Update(_mapper.Map<Cat>(request));
            return new CatUpdateResponse(failures, true);
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
