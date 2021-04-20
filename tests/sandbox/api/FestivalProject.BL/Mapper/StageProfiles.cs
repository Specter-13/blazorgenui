using AutoMapper;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Mapper
{
    public class StageProfiles : Profile
    {
        public StageProfiles()
        {

            CreateMap<StageEntity, StageCreateDto>();
            CreateMap<StageCreateDto, StageEntity>();
            CreateMap<StageEntity, StageDetailDto>();
            CreateMap<StageDetailDto,StageEntity>();

            CreateMap<StageEntity, StageForInterpretDto>()
                .ForMember(d=>d.FestivalName, o => o.MapFrom(s => s.Festival.Name));
            CreateMap<StageEntity, StageForFestivalDto>();

            CreateMap<StageForFestivalDto,StageEntity>();

            //CreateMap<StageForInterpretDto,StageEntity >()
            //    .ForMember(d => d.Festival, o => o.MapFrom(s => s.Festival.Name));
        }
    }
}
