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
    public class TestMixedDto 
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public bool IsFestival { get; set; }
        public ComplexType Complex1 { get; set; }
        public ComplexType Complex2 { get; set; }
    }
}
