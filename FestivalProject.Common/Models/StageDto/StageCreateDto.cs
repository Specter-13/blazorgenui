using System;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageCreateDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid FestivalId { get; set; }
    }
}
