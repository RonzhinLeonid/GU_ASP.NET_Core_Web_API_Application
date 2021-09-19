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
using WebApi_V2.Validations;

namespace WebApi_V2.Controllers
{
    [Route("analysis")]
    [ApiController]
    [Authorize]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public AnalysisController(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        [HttpPost("{catId:int}/add/{clinicId:int}")]
        public async Task AddCatInClinic([FromBody] AnalysisRequest request, int catId, int clinicId)
        {
            await _analysisRepository.AssignAnalysisToCat(_mapper.Map<Analysis>(request), catId, clinicId);
        }
    }
}
