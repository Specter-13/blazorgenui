using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using FestivalProject.DAL.Enums;

namespace BlazorGenUI.Tests.testdtos
{
    public class TestFromTemplateDto 
    {
        public string Name { get; set; }
        public MusicGenre Genre { get; set; }
        public string Country { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
        public bool IsFestival { get; set; }
        public DateTime Date { get; set; }
     
    }
}
