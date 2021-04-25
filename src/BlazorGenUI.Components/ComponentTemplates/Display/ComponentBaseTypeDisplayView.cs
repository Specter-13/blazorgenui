using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Display
{
    public partial class ComponentBaseTypeDisplayView<T>
    {
        [Parameter]
        public ValueElementT<T> ValueElement { get; set; }

      
    }
}
