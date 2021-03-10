using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class InterpretFacade 
    {
        private readonly InterpretRepository _repo;
        private readonly IMapper _mapper;
        public InterpretFacade(InterpretRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<InterpretListDto> GetAll()
        {
            return _mapper.Map<IList<InterpretListDto>>(_repo.GetAll());
        }

        public InterpretDetailDto GetById(Guid id)
        {
            return _mapper.Map<InterpretDetailDto>(_repo.GetById(id));
        }

        public InterpretDetailDto Create(InterpretDetailDto item)
        {
            return _mapper.Map<InterpretDetailDto>(_repo.Create(_mapper.Map<InterpretEntity>(item)));
        }

        public InterpretDetailDto Update(InterpretDetailDto item)
        {
            return _mapper.Map<InterpretDetailDto>(_repo.Update(_mapper.Map<InterpretEntity>(item)));
        }

        public void Delete(Guid id)
        {
           _repo.Delete(id);
        }
    }
}
