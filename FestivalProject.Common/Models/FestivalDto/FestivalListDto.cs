

using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.FestivalDto
{
    public class FestivalListDto : EntityBase
    {
        public string Name { get; set; }
        public MusicGenre Genre { get; set; }
        public string Country { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
    }
}
