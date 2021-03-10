using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.ReservationDto
{
    public class ReservationListDto : EntityBase
    {
        public ReservationStatus State { get; set; }
        public string Username { get; set; }
        public int Tickets { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string FestivalName { get; set; }
    }
}
