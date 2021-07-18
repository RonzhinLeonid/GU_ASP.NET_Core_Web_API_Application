using AutoMapper;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DAL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CatRequest, Cat>();
            CreateMap<Cat, CatResponses>();
        }
    }
}