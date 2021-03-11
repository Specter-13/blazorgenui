using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Interfaces;
using Fasterflect;

namespace BlazorGenUI.Reflection
{
    public class ComplexElement : IComplexElement
    {
        public ComplexElement()
        {
            ElementName = this.GetType().UnderlyingSystemType.Name;
        }
        private IList<IBaseElement> Kids { get; set; } = new List<IBaseElement>();

        public IEnumerable<IBaseElement> GetKids()
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
                    if (propertyType.IsPrimitive || (propertyType == typeof(string)) || propertyType.IsEnum)
                    {
                        //is generic
                        Type genericType = typeof(ValueElementT<>).MakeGenericType(propertyType);
                        var instance = (IValueElement) Activator.CreateInstance(genericType);

                        instance.ElementName = property.Name;
                        instance.PropertyType = propertyType;
                 
                        PropertyInfo prop = instance.GetType().GetProperty("Data");
                        prop.SetValue(instance, property.GetValue(this, null), null);
                        instance.PropertyChanged += HandlePropertyChangedAsync;
                        // Set the value of the given property on the given instance
                        Kids.Add(instance);

                    }
                    else
                    {
                       var complex = property.GetValue(this, null);
                       Kids.Add((IBaseElement)complex);
                    }

                }
            }

            //return propertyBaseDataList;
            //var propValue = context.GetType().GetProperty("TestString").GetValue(context, null);
            return Kids;
        }

        public string GetName()
        {
            return ElementName;
        }

        protected async void HandlePropertyChangedAsync(object sender, PropertyChangedEventArgs a)
        {
            await Task.Run(() =>
            {
                var castedSender = (IValueElement) sender;
                var data = castedSender.GetPropertyValue("Data");
                this.SetPropertyValue(castedSender.ElementName, data);
            });
        }

        private string ElementName { get; set; }
    }
}
