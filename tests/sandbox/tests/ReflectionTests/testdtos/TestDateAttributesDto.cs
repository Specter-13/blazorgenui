using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Tests.testdtos
{
    public class TestDateAttributesDto : ComplexElement
    {

        [Date(DateTypes.Date)]
        public DateTime Date { get; set; }
        [Date(DateTypes.DateTime)]
        public DateTime Date2 { get; set; }
        [Date(DateTypes.TimeOfDay)]
        public DateTime Date3 { get; set; }
    }
}
