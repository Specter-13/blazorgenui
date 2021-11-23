using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Enumerators.Display
{
    public partial class EnumeratorContainerDisplayView<T>
    {
        [Parameter]
        public ValueElementEnumT<T> ValueElement { get; set; }
    }
}
