﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fit4You.Core.Domain;
using Fit4You.WebApp.Models;

namespace Fit4You.WebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserData, UserInformationDisplayModel>()
                .ForMember(dest => dest.Gender, x => x.MapFrom(src => src.isMale ? "Male" : "Female"))
                .ForMember(dest => dest.AgeDisplay, x => x.MapFrom(src => String.IsNullOrEmpty(src.Age.ToString()) ? "Unknown" : src.Age.ToString()))
                .ForMember(dest => dest.HeightDisplay, x => x.MapFrom(src => String.IsNullOrEmpty(src.Height.ToString()) ? "Unknown" : src.Height.ToString()))
                .ForMember(dest => dest.WeightDisplay, x => x.MapFrom(src => String.IsNullOrEmpty(src.Weight.ToString()) ? "Unknown" : src.Weight.ToString()));

            CreateMap<UserInformationModel, UserData>()
                .ForMember(dest => dest.isMale, x => x.MapFrom(src => (bool)src.IsMale))
                .ForMember(dest => dest.Weight, x => x.MapFrom(src => (decimal)src.Weight))
                .ForMember(dest => dest.Height, x => x.MapFrom(src => (decimal)src.Height));
        }
    }
}
