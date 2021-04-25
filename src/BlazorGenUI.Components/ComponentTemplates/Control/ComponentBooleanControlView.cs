using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Control
{
    public partial class ComponentBooleanControlView
    {
        [Parameter]
        public ValueElementT<bool> ValueElement { get; set; }
        
    }
}
