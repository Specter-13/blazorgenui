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
    public class TestPrimitiveDto 
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string LogoUri { get; set; }
        public string City { get; set; }
        public bool IsFestival { get; set; }
        public DateTime Date { get; set; }
        public Single SingleNumber { get; set; }
        public float FloatNumber { get; set; }
        public double DoubleNumber { get; set; }
        public int IntNumber { get; set; }

        
    }
}
