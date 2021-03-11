using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Interfaces;
using Fasterflect;

namespace BlazorGenUI.Reflection
{
    public class EntryBase : IEntryBase
    {
   
        private IList<IPropertyBaseData> Kids { get; set; } = new List<IPropertyBaseData>();

        
        public void SetPropertyDataValue<T>(string propertyName, PropertyBaseDataT<T> data)
        {
            
            this.SetPropertyValue(propertyName, data);
        }

        public IEnumerable<IPropertyBaseData> GetKids()
        {
   
            Type underlyingSystemType = this.GetType().UnderlyingSystemType;
            var listOfProperties = underlyingSystemType.GetRuntimeProperties();
             //var kids = new IList<PropertyBaseData>;
            
                //var propertyBaseDataList = new IEnumerable<PropertyBaseData>();
            //Type type = typeof(PropertyBaseData);
            if (Kids.Count == 0)
            {
                foreach (var property in listOfProperties)
                {
                    var propertyType = property.PropertyType;
                    if (propertyType.IsPrimitive || (propertyType == typeof(string)))
                    {   
                        //is generic
                        Type genericType = typeof(PropertyBaseDataT<>).MakeGenericType(propertyType);
                        var instance = (IPropertyBaseData)Activator.CreateInstance(genericType);

                        instance.Name = property.Name;
                        instance.PropertyType = propertyType;
                        instance.Instance = this;
                        PropertyInfo prop = instance.GetType().GetProperty("Data");
                        prop.SetValue(instance, property.GetValue(this, null), null);
                        instance.PropertyChanged += HandlePropertyChangedAsync;
                        // Set the value of the given property on the given instance
                        Kids.Add(instance);
                       

                    }
                }
            }

            //return propertyBaseDataList;
            //var propValue = context.GetType().GetProperty("TestString").GetValue(context, null);
            return Kids;
        }

        protected async void HandlePropertyChangedAsync(object sender, PropertyChangedEventArgs a)
        {
            var castedSender = (IPropertyBaseData) sender;
            var data = castedSender.GetPropertyValue("Data");


            this.SetPropertyValue(castedSender.Name, data);
            //sender.Instance.SetPropertyValue(sender.Name, );
            //await InvokeAsync(StateHasChanged);
        }


    }
}
