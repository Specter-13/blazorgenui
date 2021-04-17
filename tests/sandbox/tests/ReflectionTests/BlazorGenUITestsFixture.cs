using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BlazorGenUI.Components.Renderable;
using BlazorGenUI.Reflection.Providers;
using BlazorGenUI.Reflection.Services;
using BlazorGenUI.Tests.testdtos;
using FestivalProject.DAL.Enums;

namespace ReflectionTests
{
    public class BlazorGenUITestsFixture
    {
        public BlazorGenUITestsFixture()
        {
            RenderableContent = new RenderableContentControl();
            RenderableContent.ComponentService = new ComponentService();
            RenderableContent.LayoutProvider = new LayoutProvider();
            RenderableContent.ViewTemplateProvider = new ViewTemplateProvider();
            RenderableContent.ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            SeedTestData();
        }
       
        public RenderableContentControl RenderableContent { get; set; }
        public TestComplexDto TestComplex { get; set; }
        public TestFromTemplateDto TestFromTemplate { get; set; }
        public TestDateAttributesDto TestDateAttributes { get; set; }
        public TestEnumDto TestEnum { get; set; }
        public TestPrimitiveDto TestPrimitive{ get; set; }
        public TestDateTimeOffset TestDateTimeOffset { get; set; }
        public TestArrayDto TestArray { get; set; }

        private void SeedTestData()
        {
            TestComplex = new TestComplexDto
            {
                Name = "TestComplex",
                Capacity = 20,
                Festival = new FestivalProject.BL.Models.FestivalDto.FestivalListDto
                {
                    Name = "TestFestival",
                    Genre = MusicGenre.Pop,
                    Country = "Argentina",
                    LogoUri = "logo",
                    City = "Bueno Aires",
                    IsFestival = true,
                    Date = default,
                }
            };

            TestFromTemplate = new TestFromTemplateDto
            {
                Name = "TestFestivalFromTemplate",
                Genre = MusicGenre.Pop,
                Country = "Argentina",
                LogoUri = "logo",
                City = "Bueno Aires",
                IsFestival = true,
                Date = default,
            };

            TestDateAttributes = new TestDateAttributesDto
            {
                Date = default,
                Date2 = default,
                Date3 = default
            };

            TestEnum = new TestEnumDto
            {
                Genre = MusicGenre.Rock
            };

            TestPrimitive = new TestPrimitiveDto
            {
                Name = "TestFestivalPrimitive",
                Country = "Brazil",
                LogoUri = "logo",
                City = "Rio",
                IsFestival = true,
                Date = default,
                SingleNumber = (Single)12.1,
                FloatNumber = (float)12.546,
                DoubleNumber = 12.231,
                IntNumber = 200
            };

            TestDateTimeOffset = new TestDateTimeOffset
            {
                DateWithOffset = new DateTimeOffset(2008, 6, 19, 7, 0, 0, TimeSpan.Zero)
            };

            TestArray = new TestArrayDto
            {
                BoolArray = new List<bool>
                    {true, true, true, false, false, false},
                IntArray = new List<int>
                    {1,2,3,4,5,6,7,89,1,2,3,4,5,6,78,9,1,23,6,5,4,89,7,9,5,4,6,2},
                ComplexArray = new List<TestPrimitiveDto>
                {
                    TestPrimitive, TestPrimitive, TestPrimitive, TestPrimitive
                }
                    
            };
        }
    }
}