using System;
using BlazorGenUI.Reflection.ValueElementTypes;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Enumerators.Control
{
    public partial class EnumeratorContainerControlView<T>
    {
        [Parameter]
        public ValueElementEnumT<T> ValueElement { get; set; }
        private Array Names { get; set; }
        protected override void OnInitialized()
        {
            Names = Enum.GetNames(ValueElement.PropertyType);
        }

        private void ValueChanged(ChangeEventArgs args)
        {
            var value = args.Value.ToString();
            ValueElement.Data = (T)Enum.Parse(ValueElement.PropertyType, value);
        }
    }
}
