using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates.Control
{
    public partial class ComponentBaseTypeControlView<T>
    {
        [Parameter]
        public PropertyBaseDataT<T> BaseData { get; set; }

        //[Parameter]
        //public EntryBase Context { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //await UpdateValuesOnChangeAsync<T>(BaseData);
            //BaseData.PropertyChanged += HandlePropertyChangedAsync<T>;
            //await UpdateValuesOnChangeAsync<T>(BaseData);
        }

      
    }
}
