using AutoMapper;
using BillApp.Dto;
using BillApp.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BillApp.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bills, BillsDto>().ReverseMap();
        }
    }
    
}
