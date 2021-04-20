using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Entities
{
    public class InterpretEntity : EntityBase
    {
        public string Name { get; set; }
        public string LogoUri { get; set; }
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0.00,10.00)]
        public float Rating { get; set; }
        public MusicGenre Genre { get; set; }
        public string Description { get; set; }
        public IList<MemberEntity> MemberList { get; set; }
        public IList<FestivalInterpretEntity> FestivalInterpret { get; set; }
        public IList<StageInterpretEntity> StageInterpret { get; set; }
    }
}
