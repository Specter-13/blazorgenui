using BlazorGenUI.Reflection.Attributes;
using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models.StageDto
{
    [Template("DetailTemplate")]
    public class StageForFestivalDto : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

    }
}
