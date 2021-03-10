using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UserCreateEditDto, UserEntity>();
            CreateMap<UserEntity, UserCreateEditDto>();

            CreateMap<UserAuthenticateDto, UserEntity>();
            CreateMap<UserEntity, UserAuthenticateDto>();

            CreateMap<UserEntity, UserListDto>();
            CreateMap<UserEntity, UserDetailDto>();

            CreateMap<UserDetailDto, UserDetailAuthenticateDto>().ForMember(x => x.Token, opt => opt.Ignore()); ;
           
        }
    }
}
