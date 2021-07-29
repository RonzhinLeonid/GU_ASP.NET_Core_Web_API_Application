using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;

namespace WebApi_V2.DAL
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CatRequest, Cat>();
            CreateMap<CatUpdRequest, Cat>();
            CreateMap<Cat, CatResponses>();

            CreateMap<ClinicRequest, Clinic>();
            CreateMap<ClinicUpdRequest, Clinic>();
            CreateMap<Clinic, ClinicResponses>();
        }
    }
}
