using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.BL.Models.UserDto
{
    public class UserListDto : EntityBase
    {
        public UserRoles Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; } 
    }
}
