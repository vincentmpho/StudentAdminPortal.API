﻿using AutoMapper;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Models.DTOs;

namespace StudentAdminPortal.API.Profiles 
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Student, StudentDTO>()
                .ReverseMap();

            CreateMap<Gender, GenderDTO>() 
                .ReverseMap();

            CreateMap<Address, AddressDTO>()
                .ReverseMap();
        }
    }
}
