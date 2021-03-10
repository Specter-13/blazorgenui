using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Entities
{
    public class FestivalEntity : EntityBase
    {
        public string Name { get; set; }
        public MusicGenre Genre { get; set; }
        public string Country { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public IList<StageEntity> StageList { get; set; }
        public IList<FestivalInterpretEntity> FestivalInterpret { get; set; }

    }
}
