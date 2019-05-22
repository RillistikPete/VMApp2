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
            CreateMap<Movie, MovieDTO>();
            CreateMap<MembershipType, MembershipTypeDTO>();
            CreateMap<Genre, GenreDTO>();

            CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDTO, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}