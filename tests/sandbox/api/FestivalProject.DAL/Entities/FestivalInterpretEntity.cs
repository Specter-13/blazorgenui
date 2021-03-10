using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
