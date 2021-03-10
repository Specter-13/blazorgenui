using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Interfaces;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class FestivalFacade 
    {
        private readonly FestivalRepository _repo;
        private readonly IMapper _mapper;
        public FestivalFacade(FestivalRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<FestivalListDto> GetAll()
        {
            return _mapper.Map<IList<FestivalListDto>>(_repo.GetAll());
        }

        public FestivalDetailDto GetById(Guid id)
        {
            return _mapper.Map<FestivalDetailDto>(_repo.GetById(id));
        }

        public FestivalDetailDto Create(FestivalDetailDto item)
        {
            return _mapper.Map<FestivalDetailDto>(_repo.Create(_mapper.Map<FestivalEntity>(item)));
        }

        public FestivalDetailDto Update(FestivalDetailDto item)
        {
            return _mapper.Map<FestivalDetailDto>(_repo.Update(_mapper.Map<FestivalEntity>(item)));
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
