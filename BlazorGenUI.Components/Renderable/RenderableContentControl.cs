using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.Renderable
{
    public partial class RenderableContentControl : ComponentBase
    {
        [Parameter]
        public EntryBase Context { get; set; }

        public IList<PropertyBaseData> PropertyBaseDataList { get; set; }

        protected override void OnInitialized()
        {
            var testObject = Context;
            var reflectionLibrary = new ReflectionLogic();
            var x =Context.GetType().GetRuntimeProperties();
            PropertyBaseDataList = reflectionLibrary.GetAllProperties(Context);
            //PropertyBaseDataList = Context.GetType().GetRuntimeProperties();


        }

        async Task ChangeHandler(OnChangeObject newObject)
        {
            await Task.Run(() =>
            {
                Context.SetPropertyValue(newObject.Name, newObject.Value);
            });
        }
    }
}
