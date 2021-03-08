using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageDto
{
    public class StageForFestivalDto : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

    }
}
