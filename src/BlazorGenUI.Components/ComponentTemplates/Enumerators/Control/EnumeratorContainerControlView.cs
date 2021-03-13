using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Enumerators.Control
{
    public partial class EnumeratorContainerControlView<T>
    {
        [Parameter]
        public ValueElementEnumT<T> ValueElement { get; set; }
    }
}