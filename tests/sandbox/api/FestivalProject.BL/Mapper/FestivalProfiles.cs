using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class FestivalProfiles : Profile
    {
        public FestivalProfiles()
        {
            CreateMap<FestivalEntity, FestivalDetailDto>();
            CreateMap<FestivalEntity, FestivalListDto>();
            CreateMap<FestivalListDto,FestivalEntity>();
            CreateMap<FestivalDetailDto, FestivalEntity>();
        }
    }
}
