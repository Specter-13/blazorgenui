using System.IO;
using System.Reflection;
using BlazorGenUI.Components.Renderable;
using BlazorGenUI.Tests.testdtos;
using FestivalProject.DAL.Enums;

namespace ReflectionTests
{
    public class BlazorGenUITestsFixture
    {
        public BlazorGenUITestsFixture()
        {
            RenderableContent = new RenderableContentControl();
            RenderableContent.ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

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
            };


        }
        public RenderableContentControl RenderableContent { get; set; }
        public TestComplexDto TestComplex { get; set; }
        public TestFromTemplateDto TestFromTemplate { get; set; }
        public TestDateAttributesDto TestDateAttributes { get; set; }
        public TestEnumDto TestEnum { get; set; }
        public TestPrimitiveDto TestPrimitive{ get; set; }
    }
}