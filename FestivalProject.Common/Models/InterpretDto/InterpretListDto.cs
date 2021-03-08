using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.InterpretDto
{
    public class InterpretListDto: EntityBase
    {
        public string Name { get; set; }
        public string LogoUri { get; set; }
        public float Rating { get; set; }
        public MusicGenre Genre { get; set; }
    }
}
