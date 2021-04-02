using FestivalProject.BL.Models.FestivalInterpretDto;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;
using System;
using System.Collections.Generic;
using BlazorGenUI.Reflection.Attributes;

namespace FestivalProject.BL.Models.FestivalDto
{
   
    public class FestivalDetailDto 
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

       
        public decimal Price { get; set; }
        
        public int Capacity { get; set; }

        [RenderIgnore]
        public IList<StageForFestivalDto> StageList { get; set; }
        [RenderIgnore]
        public IList<FestivalInterpretForFestivalDto> FestivalInterpret { get; set; }

    }
}
