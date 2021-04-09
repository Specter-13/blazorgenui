using System;
using System.Linq;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.ValueElementTypes;
using Xunit;

namespace ReflectionTests
{
    public class HandlePropertyChangeTests : IClassFixture<BlazorGenUITestsFixture>
    {
        private BlazorGenUITestsFixture _fixture;

        public HandlePropertyChangeTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
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
            var complex = new ComplexElement(_fixture.TestDateTimeOffset);

            //Act
            var firstKid = complex.GetChildren().First();
            ((ValueElementDateTime)firstKid).Data = expectedValue.DateTime;

            //Assert
            Assert.Equal(expectedValue, _fixture.TestDateTimeOffset.DateWithOffset);
        }
    }
}