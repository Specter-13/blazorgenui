using System;
using FestivalProject.BL.Models.InterpretDto;

namespace FestivalProject.BL.Models.StageInterpretDto
{
    public class StageInterpretBaseDto
    {
        public Guid InterpretId { get; set; }
        public InterpretListDto Interpret { get; set; }

        public int ConcertLength { get; set; }
        public DateTime ConcertStart { get; set; }
        public DateTime ConcertEnd { get; set; }
    }
}
