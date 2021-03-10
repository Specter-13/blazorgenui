using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class MemberProfiles : Profile
    {
        public MemberProfiles()
        {
            CreateMap<MemberEntity, MemberDetailDto>();
            CreateMap<MemberDetailDto,MemberEntity>();
        }
    }
}
