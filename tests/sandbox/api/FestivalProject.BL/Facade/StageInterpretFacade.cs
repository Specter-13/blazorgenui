using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class StageInterpretFacade
    {
        private readonly StageInterpretRepository _repo;
        private readonly IMapper _mapper;
        public StageInterpretFacade(StageInterpretRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public StageInterpretCreateUpdateDto Create(StageInterpretCreateUpdateDto item)
        {
            return _mapper.Map<StageInterpretCreateUpdateDto>(_repo.Create(_mapper.Map<StageInterpretEntity>(item)));
        }

        public StageInterpretCreateUpdateDto Update(StageInterpretCreateUpdateDto item)
        {
            return _mapper.Map<StageInterpretCreateUpdateDto>(_repo.Update(_mapper.Map<StageInterpretEntity>(item)));
        }

        public void Delete(Guid StageId, Guid InterpretId)
        {
            _repo.Delete(StageId, InterpretId);
        }

    }
}
