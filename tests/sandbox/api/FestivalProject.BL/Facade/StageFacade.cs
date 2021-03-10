using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class StageFacade
    {
        private readonly StageRepository _repo;
        private readonly IMapper _mapper;
        public StageFacade (StageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IList<StageDetailDto> GetAll()
        {
            return _mapper.Map<IList<StageDetailDto>>(_repo.GetAll());
        }

        public StageDetailDto GetById(Guid id)
        {
            return _mapper.Map<StageDetailDto>(_repo.GetById(id));
        }

        public StageCreateDto Create(StageCreateDto item)
        {
            return _mapper.Map<StageCreateDto>(_repo.Create(_mapper.Map<StageEntity>(item)));
        }

        public StageDetailDto Update(StageDetailDto item)
        {
            return _mapper.Map<StageDetailDto>(_repo.Update(_mapper.Map<StageEntity>(item)));
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
