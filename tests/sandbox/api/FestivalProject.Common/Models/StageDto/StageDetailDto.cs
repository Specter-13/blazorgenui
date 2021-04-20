using FestivalProject.BL.Models.FestivalDto;

namespace FestivalProject.BL.Models.StageDto
{
    
    public class StageDetailDto 
    {
      
        public string Name { get; set; }
        public int Capacity { get; set; }
        public FestivalListDto Festival { get; set; }
  
    }
}
