using System.Collections.Generic;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.StageInterpretDto;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageDto
{
    
    public class StageDetailDto 
    {
      
        public string Name { get; set; }
        public int Capacity { get; set; }
        public FestivalListDto Festival { get; set; }
  
    }
}
