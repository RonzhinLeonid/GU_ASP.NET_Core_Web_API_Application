using AutoMapper;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DAL;
using WebApi.Repository;

namespace WebApi.Controllers
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
        public void Add(CatRequest request)
        {
            _catsRepository.Add(_mapper.Map<Cat>(request));
        }

        [HttpGet]
        public IEnumerable<CatResponses> Get()
        {
            var data = _catsRepository.Get();
            return data.Select(_mapper.Map<CatResponses>);
        }
    }
}