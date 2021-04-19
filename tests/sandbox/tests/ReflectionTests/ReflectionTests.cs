using System;
using System.Collections.Generic;
using System.Linq;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.ValueElementTypes;
using Xunit;

namespace BlazorGenUI.Tests
{
    public class ReflectionTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;
        
        public ReflectionTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }


        [Fact]
        public void Reflection_GetKidsPrimitive_ReturnsCountEqual()
        {
            //Arrange
            var expectedNumber = _fixture.TestPrimitive.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestPrimitive)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void Reflection_GetKidsComplex_ReturnsCountEqual()
        {
            //Arrange
            var expectedNumber =  _fixture.TestComplex.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestComplex)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }


        [Fact]
        public void Reflection_GetKidsMixed_ReturnsCountEqual()
        {
            //Arrange
            var expectedNumber = _fixture.TestMixed.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestMixed)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void Reflection_GetKidsArray_ReturnsCountEqual()
        {
            //Arrange
            var expectedNumber = _fixture.TestArray.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestArray)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }


        [Fact]
        public void SetPropertyValue_TestPrimitiveFirstProperty_Success()
        {
            //Arrange
            var expectedValue = "Grape";
            var complex = new ComplexElement(_fixture.TestPrimitive);

            //Act
            var firstKid = complex.GetChildren().First();
            ((ValueElementT<string>)firstKid).Data = expectedValue;

            //Assert
            Assert.Equal(expectedValue, _fixture.TestPrimitive.Name);
        }
        [Fact]
        public void SetPropertyValue_TestDateTimeOffset_Success()
        {
            //Arrange
            var expectedValue = new DateTimeOffset(2018, 7, 20, 7, 0, 0, TimeSpan.Zero);
            var complex = new ComplexElement(_fixture.TestPrimitive);

            //Act
            var firstKid = complex.GetChildren().First(x=> x.RawName == "DateOffset");
            ((ValueElementDateTime)firstKid).Data = expectedValue.DateTime;

            //Assert
            Assert.Equal(expectedValue, _fixture.TestPrimitive.DateOffset);
        }

    }
}
