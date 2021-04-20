using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Exceptions;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.Models;
using BlazorGenUI.Reflection.Providers;
using BlazorGenUI.Reflection.Services;
using Fasterflect;
using Microsoft.AspNetCore.Components;

[assembly: InternalsVisibleTo("BlazorGenUI.Tests")]
namespace BlazorGenUI.Components.Renderable
{
    public partial class RenderableContentControl
    {
        [Parameter]
        public object Context { get; set; }
        [Parameter]
        public PresentationType Presentation { get; set; }
        [Parameter] 
        public LayoutTypes Layout { get; set; } = LayoutTypes.Default;
        [Parameter]
        public string IgnoredFields { get; set; }
        [Parameter] 
        public Template Template { get; set; } = Template.None;
        [Parameter]
        public string PictureFields { get; set; }
        [Parameter]
        public IDictionary<string, int> Order { get; set; }
        [Parameter]
        public IDictionary<string, string> Labels { get; set; }
        [Parameter]
        public EventCallback<bool> OnLoginSubmit  { get; set; }

        [Inject]
        public ViewTemplateProvider ViewTemplateProvider { get; set; } 
        [Inject]
        public LayoutProvider LayoutProvider { get; set; }
        [Inject]
        public ComponentService ComponentService { get; set; }

        public IComplexElement Wrapper { get; set; } 
        public Type LayoutComponentType { get; set; }
        

        protected override void OnInitialized()
        {
            if (Context == null)
            {
                throw new ContextNullException(
                    "Error! Context cannot be null! Make sure to render UI after context is set!");
            }

            ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            TrySetLayout();
            Wrapper = new ComplexElement(Context, IgnoredFields, PictureFields, Order, Labels);
           
        }

        internal void TrySetLayout()
        {
            if (Layout != LayoutTypes.Default)
            {
                var layoutInfo = LayoutProvider.GetLayoutInfo(Layout);
                LayoutComponentType = ComponentService.GetLayoutComponentType(layoutInfo.fullTypeName);
            }
            else 
            { 

                var layoutAttribute = GetAttribute<ContainerAttribute>(Context);
                if (layoutAttribute != null)
                {
                    var layoutInfo = LayoutProvider.GetLayoutInfo(layoutAttribute.GetLayout());
                    LayoutComponentType = ComponentService.GetLayoutComponentType(layoutInfo.fullTypeName);
                }
            }
        }

        internal IRenderableComponent ViewBaseLocatorBuilder(string primitiveTypeName, PresentationType presentationType)
        {
            var buildedComponentName = $"Component{primitiveTypeName}{presentationType}View";
            return ComponentService.GetComponent(buildedComponentName);

        }

        internal IRenderableComponent ViewGenericBaseLocatorBuilder(PresentationType presentationType, Type typeArg, bool isEnum)
        {
            string buildedComponentName;
            if (isEnum)
                buildedComponentName = $"EnumeratorContainer{presentationType}View`1";
            else
                buildedComponentName = $"ComponentBaseType{presentationType}View`1";
            return ComponentService.GetGenericComponent(buildedComponentName, typeArg);
        }

       
        private T GetAttribute<T>(object composeObject) where T : class
        {
            var typeAttribute = composeObject.GetType()
                .GetCustomAttributes(true)
                .ToList()
                .Find(p => p.GetType() == typeof(T)) as T;
            return typeAttribute;
        }

        internal IRenderableComponent ViewComplexLocatorBuilder(Template viewTemplate)
        {
            if (viewTemplate == Template.None) return null;

            var componentInfo = ViewTemplateProvider.GetTemplate(viewTemplate);
            var component = ComponentService.GetComponent(componentInfo.fullTypeName);
            return component;
        }
        private void OnLoginSubmitCallBack()
        {
            OnLoginSubmit.InvokeAsync(true);
        }
    }
}
