using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalProject.DAL.Entities
{
    public class StageEntity : EntityBase
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public Guid FestivalId { get; set; }
        public FestivalEntity  Festival { get; set; }
        public IList<StageInterpretEntity> StageInterpret { get; set; }
    }
}
