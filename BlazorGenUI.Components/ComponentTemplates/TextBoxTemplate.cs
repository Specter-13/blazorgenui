using System.Threading.Tasks;
using BlazorGenUI.Reflection;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.ComponentTemplates 
{
    public partial class TextBoxTemplate : ComponentBase
    {
        
        [Parameter]
        public PropertyBaseData ContextData { get; set; }
        [Parameter] 
        public EventCallback<OnChangeObject> OnChange { get; set; }



        protected async Task OnValueChanged(ChangeEventArgs __e)
        {
            await Task.Run(() =>
            {
         
                try
                {
                    ContextData.PropertyValue = __e.Value;
                    var obj = new OnChangeObject
                    {
                        Name = ContextData.PropertyName,
                        Value = __e.Value
                    };
                    OnChange.InvokeAsync(obj);

                }
                catch
                {
                    InvokeAsync(StateHasChanged);
                }
            });

        }

    }
}

