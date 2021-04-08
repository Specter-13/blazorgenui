using System;
using System.Collections.Generic;
using System.Text;
using BlazorGenUI.Reflection;
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
