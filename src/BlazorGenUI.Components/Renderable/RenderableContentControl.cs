using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.Providers;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.Renderable
{
    public partial class RenderableContentControl : ComponentBase
    {
        [Parameter]
        public object ContextBase { get; set; }
        
        
        [Parameter]
        public PresentationType Presentation { get; set; }

        [Parameter] 
        public bool OnlyRecursive { get; set; } = false;

        [Parameter] 
        public LayoutTypes Layout { get; set; } = LayoutTypes.Default;

        [Parameter]
        public string IgnoredFields { get; set; }

        [Parameter] 
        public ViewTemplate Template { get; set; } = ViewTemplate.None;
        [Parameter]
        public string PictureFields { get; set; }
        [Parameter]
        public IDictionary<string, int> Order { get; set; }

        public IComplexElement Wrapper { get; set; } 
        public Type LayoutComponentType { get; set; }


        public ViewTemplateProvider ViewTemplateProvider { get; set; } = new ViewTemplateProvider();
        public LayoutProvider LayoutProvider { get; set; } = new LayoutProvider();
        public ComponentService ComponentService { get; set; } = new ComponentService();
        

        protected override void OnInitialized()
        {
            ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            HandleLayout();
            Wrapper = new ComplexElement(ContextBase, IgnoredFields, PictureFields, Order);
           
        }

        private void HandleLayout()
        {
            if (Layout != LayoutTypes.Default)
            {
                var layoutInfo = LayoutProvider.GetLayoutInfo(Layout);
                LayoutComponentType = ComponentService.GetLayoutComponentType(layoutInfo.fullTypeName);
            }
            else 
            { 

                var layoutAttribute = GetAttribute<ContainerAttribute>(ContextBase);
                if (layoutAttribute != null)
                {
                    var layout = layoutAttribute.GetLayout();
                    var layoutInfo = LayoutProvider.GetLayoutInfo(layout);
                    LayoutComponentType = ComponentService.GetLayoutComponentType(layoutInfo.fullTypeName);
                }
            }
        }

        public IRenderableComponent ViewBaseLocatorBuilder(string primitiveTypeName, PresentationType presentationType)
        {
            var buildedComponentName = $"Component{primitiveTypeName}{presentationType}View";
            return ComponentService.GetComponent(buildedComponentName);

        }

        public IRenderableComponent ViewGenericBaseLocatorBuilder(string genericName, PresentationType presentationType, Type typeArg, bool isEnum)
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

        private IRenderableComponent ViewComplexLocatorBuilder(ViewTemplate viewTemplate)
        {
            if (viewTemplate == ViewTemplate.None) return null;

            var componentInfo = ViewTemplateProvider.GetTemplate(viewTemplate);
            var component = ComponentService.GetComponent(componentInfo.fullTypeName);
            return component;
        }
    }
}
