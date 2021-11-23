using System;

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
