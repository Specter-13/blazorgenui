using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class FestivalInterpretProfiles : Profile
    {
        public FestivalInterpretProfiles()
        {
            CreateMap<FestivalInterpretEntity, FestivalInterpretForInterpretDto>();
            CreateMap<FestivalInterpretEntity, FestivalInterpretForFestivalDto>();

            CreateMap<FestivalInterpretForInterpretDto,FestivalInterpretEntity>();
            CreateMap<FestivalInterpretForFestivalDto,FestivalInterpretEntity>();


            CreateMap<FestivalInterpretCreateUpdate, FestivalInterpretEntity>();
            CreateMap<FestivalInterpretEntity, FestivalInterpretCreateUpdate>();
        }
    }
}
