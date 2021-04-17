using System;
using System.Collections.Generic;
using System.Linq;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.ValueElementTypes;
using Xunit;

namespace ReflectionTests
{
    public class GetKidsTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;
        
        public GetKidsTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }


        [Fact]
        public void GetKids_TestPrimitiveDto_ReturnsCountEqual()
        {
            //Arrange
            var testPrimitive = _fixture.TestPrimitive;
            var expectedNumber = testPrimitive.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestPrimitive)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void GetKids_TestComplex_ReturnsCountEqual()
        {
            //Arrange
            var testComplex = _fixture.TestComplex;
            var expectedNumber = testComplex.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestComplex)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void GetKids_TestDateAttributes_ReturnsCountEqual()
        {
            //Arrange
            var testDateAttributes = _fixture.TestDateAttributes;
            var expectedNumber = testDateAttributes.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestDateAttributes)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void GetKids_TestEnum_ReturnsCountEqual()
        {
            //Arrange
            var testEnum = _fixture.TestEnum;
            var expectedNumber = testEnum.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestEnum)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void GetKids_TestArray_ReturnsCountEqual()
        {
            //Arrange
            var testEnum = _fixture.TestArray;
            var expectedNumber = testEnum.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestArray)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        [Fact]
        public void GetKids_TestDateTimeOffset_ReturnsCountEqual()
        {
            //Arrange
            var testEnum = _fixture.TestDateTimeOffset;
            var expectedNumber = testEnum.GetType().GetProperties().Length;
            //Act
            var actualNumber = (new ComplexElement(_fixture.TestDateTimeOffset)).GetChildren().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

    }
}
