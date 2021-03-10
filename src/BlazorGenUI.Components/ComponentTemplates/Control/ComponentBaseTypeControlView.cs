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

        [Parameter]
        public EntryBase Context { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BaseData.PropertyChanged += HandlePropertyChangedAsync<T>;
            //await UpdateValuesOnChangeAsync<T>(BaseData);
        }

        protected async void HandlePropertyChangedAsync<T>(object sender, PropertyChangedEventArgs a)
        {
            var castedSender = (PropertyBaseDataT<T>)sender;

            Context.SetPropertyValue(castedSender.Name, castedSender.Data);
            //sender.Instance.SetPropertyValue(sender.Name, );
            //await InvokeAsync(StateHasChanged);
        }
    }
}
