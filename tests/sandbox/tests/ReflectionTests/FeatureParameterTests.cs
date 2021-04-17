using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Components.Layouts;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Exceptions;
using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components.Rendering;
using ReflectionTests;
using Xunit;

namespace BlazorGenUI.Tests
{
   public class FeatureParameterTests: IClassFixture<BlazorGenUITestsFixture>
   {
       private string _attributeNameChild = "ChildContent";
        private BlazorGenUITestsFixture _fixture;

        public FeatureParameterTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }
        // LAYOUT TESTS
        [Fact]
        public void SetWrapLayout_TestPrimitive_Success()
        {
            //Arrange
            _fixture.RenderableContent.Layout = Reflection.Enums.LayoutTypes.Wrap;
            var complex = new ComplexElement(_fixture.TestPrimitive);
            var __builder = new RenderTreeBuilder();

            //Act
            _fixture.RenderableContent.TrySetLayout();
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var children = frames.Array.AsEnumerable().Where(x => x.AttributeName == "LayoutType");

            //Assert
            foreach (var child in children)
            {
                Assert.True((Type)child.AttributeValue == typeof(WrapPanelLayout));
            }

        }

        // RENDERIGNORE TESTS
        [Fact]
        public void RenderIgnore_TestPrimitive_Success()
        {
            //Arrange
            var ignoredFields = "Date, IsFestival, City";
            var complex = new ComplexElement(_fixture.TestPrimitive,
                ignoredFields,
                null,
                null,
                null);
            var expectedCount = 7;
            var __builder = new RenderTreeBuilder();


            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var actualCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(expectedCount, actualCount);
        }

        // ORDER TESTS
        [Fact]
        public void OrderChanged_TestPrimitive_Success()
        {
            //Arrange
            var order = new Dictionary<string,int>
            {
                {"Name",3}, {"City",0}
            };
            var complex = new ComplexElement(_fixture.TestPrimitive,
                null,
                null,
                order,
                null);


            //Act
            var children = complex.GetChildren();

            //Assert
            Assert.Equal("City", children.First().RawName);
            Assert.Equal("Name", children.ElementAt(3).RawName);

     
        }

        [Fact]
        public void OrderIncorrectIndex_TestPrimitive_IncorrectOrderExceptionThrow()
        {
            //Arrange
            var order = new Dictionary<string, int>
            {
                {"Name",50}
            };
            var complex = new ComplexElement(_fixture.TestPrimitive,
                null,
                null,
                order,
                null);

            //Act
            //Assert
            Assert.Throws<IncorrectOrderException>(() => complex.GetChildren());


        }
        [Fact]
        public void OrderIncorrectName_TestPrimitive_IncorrectOrderExceptionThrow()
        {
            //Arrange
            var order = new Dictionary<string, int>
            {
                {"asdrewq",3}
            };
            var complex = new ComplexElement(_fixture.TestPrimitive,
                null,
                null,
                order,
                null);

            //Act
            //Assert
            Assert.Throws<IncorrectOrderException>(() => complex.GetChildren());

        }
    }
}
