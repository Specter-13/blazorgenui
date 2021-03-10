using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.Renderable
{
    public partial class RenderableContentControl : ComponentBase
    {
        [Parameter]
        public EntryBase ContextBase { get; set; }
        
        
        [Parameter]
        public PresentationType Presentation { get; set; }

        //public IList<PropertyBaseData> PropertyBaseDataList { get; set; }

        public ComponentService ComponentService { get; set; } = new ComponentService();

        protected override void OnInitialized()
        {
            
            ComponentService.LoadComponents(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var reflectionLibrary = new ReflectionLogic();
           // var x =ParentObject.GetType().GetRuntimeProperties();
            //PropertyBaseDataList = reflectionLibrary.GetAllProperties(ParentObject);
            //PropertyBaseDataList = ParentObject.GetType().GetRuntimeProperties();


        }

        public IRenderableComponent ViewLocatorBuilder(string primitiveTypeName, PresentationType presentationType)
        {
            var buildedComponentName = $"Component{primitiveTypeName}{presentationType}View";
            return ComponentService.GetComponent(buildedComponentName);

        }

        public IRenderableComponent ViewGenericLocatorBuilder(string genericName, PresentationType presentationType, Type typeArg, bool isEnum)
        {
            string buildedComponentName;
            if (isEnum)
                buildedComponentName = $"EnumeratorContainer{presentationType}View`1";
            else
                buildedComponentName = $"ComponentBaseType{presentationType}View`1";
            return ComponentService.GetGenericComponent(buildedComponentName, typeArg);
        }

        //async Task ChangeHandler(OnChangeObject newObject)
        //{
        //    await Task.Run(() =>
        //    {
        //        ParentObject.SetPropertyValue(newObject.Name, newObject.Value);
        //    });
        //}
    }
}
