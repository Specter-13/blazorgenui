using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Entities
{
    public class ReservationEntity : EntityBase
    {
        public ReservationStatus State { get; set; }
        public int Tickets { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid FestivalId { get; set; }
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
        public FestivalEntity Festival { get; set; }
    }
}
