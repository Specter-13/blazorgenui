using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalProject.DAL.Entities
{
    public class StageInterpretEntity
    {
        public Guid InterpretId { get; set; }
        public InterpretEntity Interpret { get; set; }
        public Guid StageId { get; set; }
        public StageEntity Stage { get; set; }

        public int ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertEnd { get; set; }
    }
}
