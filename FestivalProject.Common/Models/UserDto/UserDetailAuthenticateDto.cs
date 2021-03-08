using System.Collections.Generic;
using FestivalProject.BL.Models.ReservationDto;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.UserDto
{
    public class UserDetailAuthenticateDto : EntityBase
    {
        public UserRoles Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Psc { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public IList<ReservationListDto> ReservationList { get; set; }
    }
}
