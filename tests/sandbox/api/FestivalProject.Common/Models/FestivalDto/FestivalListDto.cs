

using System;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.FestivalDto 
{
    //[Template(ViewTemplate.DetailViewTemplate)]
    public class FestivalListDto : ComplexElement
    {
        public string Name { get; set; }
        public MusicGenre Genre { get; set; }
        public string Country { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
        public bool IsFestival { get; set; }
        [Date(DateTypes.Date)]
        public DateTime Date { get; set; }
        [Date(DateTypes.DateTime)]
        public DateTime Date2 { get; set; }
        [Date(DateTypes.TimeOfDay)]
        public DateTime Date3 { get; set; }

    }
}
