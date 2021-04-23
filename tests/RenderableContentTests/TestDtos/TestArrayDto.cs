using System.Collections.Generic;


namespace BlazorGenUI.Tests.testdtos
{
    public class TestArrayDto
    {
        public List<bool> BoolArray { get; set; }
        public List<int> IntArray { get; set; }
        public List<TestPrimitiveDto> ComplexArray { get; set; }
    }
}