using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Display
{
    public partial class ComponentBooleanDisplayView
    {
        [Parameter]
        public ValueElementT<bool> ValueElement { get; set; }
        
    }
}
