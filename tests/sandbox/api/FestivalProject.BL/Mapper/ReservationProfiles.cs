using AutoMapper;
using FestivalProject.BL.Models.ReservationDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
   public class ReservationProfiles : Profile
    {
        public ReservationProfiles()
        {
            CreateMap<ReservationListDto, ReservationEntity>();
            CreateMap<ReservationCreateUpdate, ReservationEntity>();

            CreateMap<ReservationEntity, ReservationListDto>()
                .ForMember(d => d.FestivalName, o => o.MapFrom(s => s.Festival.Name))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.Username));
           
            CreateMap<ReservationEntity,ReservationCreateUpdate > ();
        }
    }
}
