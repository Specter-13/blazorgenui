using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.DAL;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class FestivalInterpretFacade
    {
        private readonly FestivalInterpretRepository _repo;
        private readonly IMapper _mapper;

        public FestivalInterpretFacade(FestivalInterpretRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public FestivalInterpretCreateUpdate Create(FestivalInterpretCreateUpdate item)
        {
            return _mapper.Map<FestivalInterpretCreateUpdate>(_repo.Create(_mapper.Map<FestivalInterpretEntity>(item)));
        }

        public FestivalInterpretCreateUpdate Update(FestivalInterpretCreateUpdate item)
        {
            return _mapper.Map<FestivalInterpretCreateUpdate>(_repo.Update(_mapper.Map<FestivalInterpretEntity>(item)));
        }

        public void Delete(Guid id1, Guid id2)
        {
            _repo.Delete(id1, id2);
        }
    }
}
