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
        public IComplexElement ContextBase { get; set; }
        
        
        [Parameter]
        public PresentationType Presentation { get; set; }

        [Parameter] 
        public bool OnlyRecursive { get; set; } = false;



        public ComponentService ComponentService { get; set; } = new ComponentService();
        public ViewTemplateProvider ViewTemplateProvider { get; set; } = new ViewTemplateProvider();

        protected override void OnInitialized()
        {
            ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
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

       
        private T GetAttribute<T>(IBaseElement composeObject) where T : class
        {
            var typeAttribute = composeObject.GetType()
                .GetCustomAttributes(true)
                .ToList()
                .Find(p => p.GetType() == typeof(T)) as T;
            return typeAttribute;
        }

        private IRenderableComponent ViewComplexLocatorBuilder(TemplateAttribute typeAttribute)
        {
            if (typeAttribute == null) return null;

            var viewTemplate = typeAttribute.GetViewTemplate();
            var componentInfo = ViewTemplateProvider.GetTemplate(viewTemplate);
            var component = ComponentService.GetComponent(componentInfo.fullTypeName);
            return component;
        }
    }
}
