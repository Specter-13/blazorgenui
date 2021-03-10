using System;
using FestivalProject.BL.Models.StageDto;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretForFestivalDto
    {
        public StageForFestivalDto Stage { get; set; }
        public Guid StageId { get; set; }

        public int ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertEnd { get; set; }
    }
}
