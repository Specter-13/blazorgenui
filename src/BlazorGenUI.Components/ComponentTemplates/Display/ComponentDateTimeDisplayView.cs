using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Display
{
    public partial class ComponentDateTimeDisplayView
    {
        [Parameter]
        public ValueElementDateTime ValueElement { get; set; }
       
    }
}