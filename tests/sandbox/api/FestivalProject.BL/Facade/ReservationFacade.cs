using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.ReservationDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Repositories;

namespace FestivalProject.BL.Facade
{
    public class ReservationFacade
    {
        private readonly ReservationRepository _repo;
        private readonly IMapper _mapper;
        public ReservationFacade(ReservationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public IList<ReservationListDto> GetAll()
        {
            return _mapper.Map<IList<ReservationListDto>>(_repo.GetAll());
        }

        public ReservationCreateUpdate GetById(Guid id)
        {
            return _mapper.Map<ReservationCreateUpdate>(_repo.GetById(id));
        }

        public int GetTicketsCountByFestivalId(Guid FestivalId)
        {
            return _repo.GetTicketsCountByFestivalId(FestivalId);
        }

        public ReservationCreateUpdate Create(ReservationCreateUpdate item)
        {
            return _mapper.Map<ReservationCreateUpdate>(_repo.Create(_mapper.Map<ReservationEntity>(item)));
        }

        public ReservationCreateUpdate Update(ReservationCreateUpdate item)
        {
            return _mapper.Map<ReservationCreateUpdate>(_repo.Update(_mapper.Map<ReservationEntity>(item)));
        }

        public void Delete(Guid id)
        {
            _repo.Delete(id);
        }
    }
}
