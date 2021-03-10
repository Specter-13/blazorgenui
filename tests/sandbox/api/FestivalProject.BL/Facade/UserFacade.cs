using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.UserDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class UserFacade 
    {
        private readonly UserRepository _repo;
        private readonly IMapper _mapper;
        public UserFacade(UserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<UserListDto> GetAll()
        {
            return _mapper.Map<IList<UserListDto>>(_repo.GetAll());
        }

        public UserDetailDto GetById(Guid id)
        {
            return _mapper.Map<UserDetailDto>(_repo.GetById(id));
        }
        public UserDetailDto GetByUsername(string username)
        {
            return _mapper.Map<UserDetailDto>(_repo.GetByUsername(username));
        }
        public UserAuthenticateDto GetUserPassword(Guid id)
        {
            return _mapper.Map<UserAuthenticateDto>(_repo.GetById(id));
        }

        public UserCreateEditDto Create(UserCreateEditDto item)
        {
            return _mapper.Map<UserCreateEditDto>(_repo.Create(_mapper.Map<UserEntity>(item)));
        }

        public UserCreateEditDto Update(UserCreateEditDto item)
        {
            return _mapper.Map<UserCreateEditDto>(_repo.Update(_mapper.Map<UserEntity>(item)));
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
