using System;
using System.Collections.Generic;
using System.Linq;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.ValueElementTypes;
using Xunit;

namespace ReflectionTests
{
    public class ReflectionTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;
        
        public ReflectionTests(BlazorGenUITestsFixture fixture)
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
            var actualNumber = testPrimitive.GetKids().Count();
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
            var actualNumber = testComplex.GetKids().Count();
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
            var actualNumber = testDateAttributes.GetKids().Count();
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
            var actualNumber = testEnum.GetKids().Count();
            //Assert
            Assert.Equal(expectedNumber, actualNumber);
        }

        //[Fact]
        //public void SetPropertyValue_TestPrimitive_Success()
        //{
        //    //Arrange
        //    var firstPropertyName = "Name";
        //    var expectedValue = "Grape";
        //    //Act
        //    var firstKid = _fixture.TestPrimitive.GetKids().First();
        //    ((ValueElementT<string>) firstKid).Data = expectedValue;


        //    //Assert
        //    //Assert.Equal(firstPropertyName, firstKid.RawName);
        //    Assert.Equal(expectedValue, _fixture.TestPrimitive.Name);
        //}
    }
}
