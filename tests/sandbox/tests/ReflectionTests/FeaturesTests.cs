using System;
using System.Collections.Generic;
using System.Linq;
using BlazorGenUI.Components.Layouts;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Exceptions;
using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace BlazorGenUI.Tests
{
   public class FeaturesTests: IClassFixture<BlazorGenUITestsFixture>
   {
       private string _attributeNameChild = "ChildContent";
        private BlazorGenUITestsFixture _fixture;

        public FeaturesTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }
        // LAYOUT TESTS
        [Fact]
        public void Feature_SetWrapLayout_Success()
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
        public void Feature_RenderIgnore_Success()
        {
            //Arrange
            var ignoredFields = "Date, IsFestival, FloatNumber";
            var complex = new ComplexElement(_fixture.TestPrimitive,
                ignoredFields,
                null,
                null,
                null);
            var expectedCount = _fixture.TestPrimitive.GetType().GetProperties().Length - 3;
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
        public void Feature_OrderChanged_Success()
        {
            //Arrange
            var order = new Dictionary<string,int>
            {
                {"Name",3}, {"FloatNumber",0}
            };
            var complex = new ComplexElement(_fixture.TestPrimitive,
                null,
                null,
                order,
                null);

            //Act
            var children = complex.GetChildren();
            //Assert
            Assert.Equal("FloatNumber", children.First().RawName);
            Assert.Equal("Name", children.ElementAt(3).RawName);

     
        }

        [Fact]
        public void Feature_OrderIncorrectIndex_IncorrectOrderExceptionThrow()
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
        public void Feature_OrderIncorrectName_IncorrectOrderExceptionThrow()
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

        [Fact]
        public void Feature_SetCustomName_Success()
        {
            //Arrange
            var label = new Dictionary<string, string>
            {
                {"Name","meno"},
                {"Date","Datum"}
            };
            var complex = new ComplexElement(_fixture.TestPrimitive,
                null,
                null,
                null,
                label);

            //Act
            var children = complex.GetChildren();
            var childName = children.First(x => x.RawName == "Name");
            var childDate = children.First(x => x.RawName == "Date");
            //Assert
            Assert.Equal("meno", childName.AttributeName);
            Assert.Equal("Datum", childDate.AttributeName);

        }

        [Fact]
        public void Feature_AttributeCustomName_Picture_RenderIgnore_Date_RadioButtons_Success()
        {
            //Arrange
            var complex = new ComplexElement(_fixture.TestAttribute);
           
            //Act
            var children = complex.GetChildren();
            var childName = children.First(x => x.RawName == "Name");
            var childPicture = (ValueElementT<string>)children.First(x => x.RawName == "PictureUri");
            var childIgnore = children.First(x => x.RawName == "IsFestival");
            var childDate = (ValueElementDateTime)children.First(x => x.RawName == "Date");
            var childEnum = (ValueElementEnumT<EnumType>)children.First(x => x.RawName == "MyEnum");
            
            //Assert
            Assert.NotNull(childName.AttributeName);
            Assert.Equal("Nazov", childName.AttributeName);
            Assert.True(childPicture.IsPicture);
            Assert.True(childIgnore.IsIgnored);
            Assert.Equal(DateTypes.Date, childDate.DateType);
            Assert.True( childEnum.IsRadio);

        }
    }
}
