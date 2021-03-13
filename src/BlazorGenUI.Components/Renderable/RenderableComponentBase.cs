using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Interfaces;
using Fasterflect;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.Renderable
{
    public class RenderableComponentBase : ComponentBase, IRenderableComponent
    {

        //public async Task UpdateValuesOnChangeAsync<T>(PropertyBaseDataT<T> tag)
        //{

        //    await Task.Run(() =>
        //    {
        //        (tag).PropertyChanged += HandlePropertyChangedAsync<T>;

        //    });
        //}

        //protected async void HandlePropertyChangedAsync<T>(object sender, PropertyChangedEventArgs a)
        //{
        //    var castedSender = (PropertyBaseDataT<T>)sender;
            

        //    castedSender.Instance.SetPropertyValue(castedSender.RawName, castedSender.Data);
        //    //sender.Instance.SetPropertyValue(sender.RawName, );
        //    //await InvokeAsync(StateHasChanged);
        //}
    }
}
