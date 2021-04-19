using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Components.Layouts;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Exceptions;
using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components.Rendering;
using Xunit;

namespace BlazorGenUI.Tests
{
   public class FundamentalTests: IClassFixture<BlazorGenUITestsFixture>
   {

       //what testing _ testtype _ result
       private string _attributeNameChild = "ChildContent";
        private BlazorGenUITestsFixture _fixture;

        public FundamentalTests(BlazorGenUITestsFixture fixture)
        {
            this._fixture = fixture;
        }
     
        [Fact]
        public void ComponentService_GetComponentControl_IsNotNull()
        {
            //Arrange
            var componentName = "ComponentBooleanControlView";
            //Act
            var component = _fixture.RenderableContent.ComponentService.GetComponent(componentName);
            //Assert
            Assert.NotNull(component);

        }

        [Fact]
        public void ComponentService_GetComponentDisplay_IsNotNull()
        {
            //Arrange
            var componentName = "ComponentBooleanDisplayView";
            //Act
            var component = _fixture.RenderableContent.ComponentService.GetComponent(componentName);
            //Assert
            Assert.NotNull(component);

        }

        [Fact]
        public void ComponentService_GetComponentUnknown_IsNull()
        {
            //Arrange
            var componentName = "UknownName";
            //Act
            var component = _fixture.RenderableContent.ComponentService.GetComponent(componentName);
            //Assert
            Assert.Null(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorControl_IsNotNull()
        {
            //Arrange
            var typeName = "Boolean";
            PresentationType presentation = PresentationType.Control;
            //Act
            var component = _fixture.RenderableContent.ViewBaseLocatorBuilder(typeName, presentation);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorDisplay_IsNotNull()
        {
            //Arrange
            var typeName = "DateTime";
            PresentationType presentation = PresentationType.Display;
            //Act
            var component = _fixture.RenderableContent.ViewBaseLocatorBuilder(typeName, presentation);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorGenericControl_IsNotNull()
        {
            //Arrange
            Type genericType = typeof(int);
            PresentationType presentation = PresentationType.Control;
            //Act
            var component = _fixture.RenderableContent.ViewGenericBaseLocatorBuilder(presentation, genericType, false);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorGenericDisplay_IsNotNull()
        {
            //Arrange
            Type genericType = typeof(decimal);
            PresentationType presentation = PresentationType.Display;
            //Act
            var component = _fixture.RenderableContent.ViewGenericBaseLocatorBuilder(presentation, genericType, false);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorGenericEnumControl_IsNotNull()
        {
            //Arrange
            Type genericType = typeof(EnumType);
            PresentationType presentation = PresentationType.Control;
            //Act
            var component = _fixture.RenderableContent.ViewGenericBaseLocatorBuilder(presentation, genericType, true);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewBaseLocatorGenericEnumDisplay_IsNotNull()
        {
            //Arrange
            Type genericType = typeof(EnumType);
            PresentationType presentation = PresentationType.Display;
            //Act
            var component = _fixture.RenderableContent.ViewGenericBaseLocatorBuilder(presentation, genericType, true);
            //Assert
            Assert.NotNull(component);
        }

        [Fact]
        public void Locator_ViewComplexLocatorBuilder_IsNotNull()
        {
            //Arrange
            Template template = Template.DetailView;
            //Act
            var component = _fixture.RenderableContent.ViewComplexLocatorBuilder(template);
            //Assert
            Assert.NotNull(component);
        }

      
    }
}
