using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VMApp2.DTOs;
using VMApp2.Models;

namespace VMApp2.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}