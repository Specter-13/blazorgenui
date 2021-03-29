using System;
using System.Collections.Generic;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using FestivalProject.BL.Models.StageDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.FestivalDto 
{
    [Container(LayoutTypes.Wrap)]
    public class FestivalListDto 
    {
        [RenderIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public MusicGenre Genre { get; set; }
        public string Country { get; set; }
        [RenderIgnore]
        public string LogoUri { get; set; }
        public string City { get; set; }
        public bool IsFestival { get; set; }
        //[Date(DateTypes.Date)] 
        public DateTime Date { get; set; }

    }
}
