using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BlazorGenUI.Components.Renderable;
using BlazorGenUI.Reflection.Providers;
using BlazorGenUI.Reflection.Services;
using BlazorGenUI.Tests;
using BlazorGenUI.Tests.testdtos;
using FestivalProject.DAL.Enums;

namespace BlazorGenUI.Tests
{
    public class BlazorGenUITestsFixture
    {
        public BlazorGenUITestsFixture()
        {
            RenderableContent = new RenderableContentControl
            {
                ComponentService = new ComponentService(),
                LayoutProvider = new LayoutProvider(),
                ViewTemplateProvider = new ViewTemplateProvider()
            };
            RenderableContent.ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            SeedTestData();
        }
       
        public RenderableContentControl RenderableContent { get; set; }
        public TestComplexDto TestComplex { get; set; }
        public TestMixedDto TestMixed { get; set; }
        public TestPrimitiveDto TestPrimitive{ get; set; }
        public TestArrayDto TestArray { get; set; }
        public TestAttributeDto TestAttribute { get; set; }

        private void SeedTestData()
        {
            TestComplex = new TestComplexDto
            {
              
                Complex1 = new ComplexType
                {
                    Name = "complex1",
                    Country = "slovakia",
                    Genre = EnumType.Value1
                },

                Complex2 = new ComplexType
                {
                    Name = "complex2",
                    Country = "czech",
                    Genre = EnumType.Value1
                },

                Complex3 = new ComplexType
                {
                    Name = "complex3",
                    Country = "poland",
                    Genre = EnumType.Value1
                }

            };


            TestMixed = new TestMixedDto
            {
                Date = default,
                Name = "mixed",
                IsFestival = false,
                Complex1 = new ComplexType
                {
                    Name = "complex1",
                    Country = "slovakia",
                    Genre = EnumType.Value1
                },

                Complex2 = new ComplexType
                {
                    Name = "complex2",
                    Country = "czech",
                    Genre = EnumType.Value1
                },
            };

            TestPrimitive = new TestPrimitiveDto
            {
                Name = "TestFestivalPrimitive",
                IsFestival = true,
                Date = default,
                DateOffset = new DateTimeOffset(2008, 6, 19, 7, 0, 0, TimeSpan.Zero),
                SingleNumber = (Single)12.1,
                FloatNumber = (float)12.546,
                DecimalNumber = (decimal)123.5476,
                DoubleNumber = 12.231,
                IntNumber = 200,
                MyEnum = EnumType.Value3
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

            TestAttribute = new TestAttributeDto
            {
                Name = "nazov",
                PictureUri = "fadsfdsafasdfafa",
                IsFestival = false,
                Date = default,
                DateOffset = default,
                FloatNumber = 0,
                DoubleNumber = 0,
                DecimalNumber = 0,
                IntNumber = 0,
                MyEnum = EnumType.Value1
            };

        }
    }
}