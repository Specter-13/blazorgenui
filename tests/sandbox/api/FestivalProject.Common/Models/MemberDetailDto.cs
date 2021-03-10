using FestivalProject.DAL.Entities;

namespace FestivalProject.BL.Models
{
    public class MemberDetailDto: EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
