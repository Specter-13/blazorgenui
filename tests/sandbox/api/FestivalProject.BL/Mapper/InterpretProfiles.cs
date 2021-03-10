using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class InterpretProfiles : Profile
    {
        public InterpretProfiles()
        {
            CreateMap<InterpretEntity, InterpretDetailDto>();
            CreateMap<InterpretEntity, InterpretListDto>();

            CreateMap<InterpretDetailDto, InterpretEntity>();
            CreateMap<InterpretListDto, InterpretEntity>();
        }
    }
}
