using System;
using System.Collections.Generic;
using System.Text;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Entities
{
    public class UserEntity : EntityBase
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
        public string Password { get; set; }

        public IList<ReservationEntity> ReservationList { get; set; }
        
        
    }
}
