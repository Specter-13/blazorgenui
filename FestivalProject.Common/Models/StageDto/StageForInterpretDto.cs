using System.Collections.Generic;
using FestivalProject.BL.Models.StageInterpretDto;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageForInterpretDto 
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string FestivalName { get;set; }
        public IList<StageInterpretForInterpretDto> StageInterpret { get; set; }

    }
}
