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
    public class TestEnumDto : ComplexElement
    {
        public MusicGenre Genre { get; set; }
       
    }
}
