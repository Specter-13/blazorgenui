using System;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretCreateUpdateDto
    {
        public Guid InterpretId { get; set; }
        public Guid StageId { get; set; }

        public int ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertEnd { get; set; }
    }
}
