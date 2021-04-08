using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.ValueElementTypes;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Display
{
    public partial class ComponentBaseTypeDisplayView<T>
    {
        [Parameter]
        public ValueElementT<T> ValueElement { get; set; }

        //[Parameter]
        //public EntryBase Context { get; set; }

      

      
    }
}
