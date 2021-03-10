using System.Collections.Generic;
using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.InterpretDto
{
    public class InterpretDetailDto : EntityBase
    {
        public string Name { get; set; }
        public string LogoUri { get; set; }
        public float Rating { get; set; }
        public MusicGenre Genre { get; set; }
        public string Description { get; set; }
        public IList<MemberDetailDto> MemberList { get; set; }
        public IList<FestivalInterpretForInterpretDto> FestivalInterpret { get; set; }
        public IList<StageInterpretForInterpretDto> StageInterpret { get; set; }
    }
}
