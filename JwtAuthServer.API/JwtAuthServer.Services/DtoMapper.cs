using AutoMapper;
using JwtAuthServer.Core.DTOs;
using JwtAuthServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthServer.Services
{
    public class DtoMapper : Profile
    {

        public DtoMapper()
        {
            CreateMap<ProductDto,Product>().ReverseMap();
            CreateMap<UserAppDto,UserApp>().ReverseMap();

        }
    }
}
