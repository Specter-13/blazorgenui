using System.Linq;
using BlazorGenUI.Reflection;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace BlazorGenUI.Tests
{
    public class RenderableContentTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;
        private string _attributeNameChild = "ChildContent";
        public RenderableContentTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }
        [Fact]
        public void GenerateObject_TestPrimitive_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestPrimitive);
            var expectedCount = complex.GetChildren().Count();
            var __builder = new RenderTreeBuilder();

            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var vortexAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(vortexAttributeCount, expectedCount);
        }
        [Fact]
        public void GenerateObject_TestMixed_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestMixed);
            var expectedCount = complex.GetChildren().Count();
            var __builder = new RenderTreeBuilder();

            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var vortexAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(vortexAttributeCount, expectedCount);
        }

        [Fact]
        public void GenerateObject_TestComplex_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestComplex);
            var expectedCount = complex.GetChildren().Count();
            var __builder = new RenderTreeBuilder();

            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var vortexAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(vortexAttributeCount, expectedCount);
        }


        [Fact]
        public void GenerateObject_TestArray_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestArray);
            var expectedCount = complex.GetChildren().Count();
            var __builder = new RenderTreeBuilder();

            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var vortexAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(vortexAttributeCount, expectedCount);
        }

        [Fact]
        public void GenerateObject_TestAttribute_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestAttribute);
            var expectedCount = complex.GetChildren().Count() - 1; //-1 because one element is ignored
            var __builder = new RenderTreeBuilder();

            //Act
            var renderer = _fixture.RenderableContent.RenderComponent(complex);
            renderer.Invoke(__builder);
            var frames = __builder.GetFrames();
            var vortexAttributeCount = frames.Array.AsEnumerable().Where(x => x.AttributeName == _attributeNameChild).Count();

            //Assert
            Assert.Equal(vortexAttributeCount, expectedCount);
        }

    }
}