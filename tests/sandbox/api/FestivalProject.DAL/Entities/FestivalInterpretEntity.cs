using System;

namespace FestivalProject.DAL.Entities
{
    public class FestivalInterpretEntity 
    {
        
        public Guid FestivalId { get; set; }
        public FestivalEntity Festival { get; set; }
       
        public Guid InterpretId { get; set; }
        public InterpretEntity Interpret { get; set; }
    }
}
