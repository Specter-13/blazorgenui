using System;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;


namespace BlazorGenUI.Tests.testdtos
{
    public class TestAttributeDto
    {
        [AttributeName("Nazov")]
        public string Name { get; set; }
        [Picture]
        public string PictureUri { get; set; }
        [RenderIgnore]
        public bool IsFestival {get; set;}
        [Date(DateTypes.Date)]
        public DateTime Date { get; set; }
        public DateTimeOffset DateOffset { get; set; }
        public float FloatNumber { get; set; }
        public double DoubleNumber { get; set; }
        public decimal DecimalNumber { get; set; }
        public int IntNumber { get; set; }
        [RadioButtonsEnum]
        public EnumType MyEnum { get; set; }
    }
}