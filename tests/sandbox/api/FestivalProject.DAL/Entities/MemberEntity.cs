using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalProject.DAL.Entities
{
    public class MemberEntity: EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid InterpretId { get; set; }
        public InterpretEntity Interpret { get; set; }
    }
}
