using BlazorGenUI.Reflection;
using FestivalProject.BL.Models.FestivalDto;

namespace BlazorGenUI.Tests.testdtos
{
    public class TestComplexDto 
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public FestivalListDto Festival { get; set; }
    }
}