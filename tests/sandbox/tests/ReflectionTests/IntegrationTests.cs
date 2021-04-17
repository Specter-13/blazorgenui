﻿using System.Linq;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components.Rendering;
using ReflectionTests;
using Xunit;

namespace BlazorGenUI.Tests
{
    public class IntegrationTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;
        private string _attributeNameChild = "ChildContent";
        public IntegrationTests(BlazorGenUITestsFixture fixture)
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
        public void GenerateObject_TestDate_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestDateAttributes);
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
        public void GenerateObject_TestDateOffset_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestDateTimeOffset);
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
        public void GenerateObject_TestEnum_ChildrenCountEqual()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestEnum);
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

    }
}