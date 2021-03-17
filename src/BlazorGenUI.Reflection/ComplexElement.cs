using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using BlazorGenUI.Reflection.ValueElementTypes;
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
        private string ElementName { get; set; }

        public object EncapsulatedDto { get; set; }

        public IEnumerable<IBaseElement> GetKids()
        {
            var listOfProperties = EncapsulatedDto.GetType().UnderlyingSystemType.GetRuntimeProperties();
     
            if (Kids.Count == 0)
            {
                foreach (var property in listOfProperties)
                {
                    var propertyType = property.PropertyType;
                    if (propertyType.IsPrimitive || 
                        (propertyType == typeof(string))
                        )
                    {
                        //is generic
                        var instance = CreateValueElementT(propertyType, property);
                        Kids.Add(instance);
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        var instance = CreateValueElementDateTime(propertyType, property);
                        Kids.Add(instance);
                    }
                    else if (propertyType.IsEnum)
                    {
                        var instance = CreateValueElementEnumT(propertyType, property);
                        Kids.Add(instance);
                    }
                    //complex  
                    else
                    {
                       var dto = property.GetValue(this, null);
                       var complex = new ComplexElement();
                       complex.EncapsulatedDto = dto;
                       Kids.Add(complex);
                    }

                }
            }
            return Kids;
        }

        private IValueElement CreateValueElementEnumT(Type propertyType, PropertyInfo property)
        {
            Type genericType = typeof(ValueElementEnumT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);

            instance.RawName = property.Name;
            instance.PropertyType = propertyType;

            PropertyInfo prop = instance.GetType().GetProperty("Data");
            prop.SetValue(instance, property.GetValue(EncapsulatedDto, null), null);
            instance.PropertyChanged += HandlePropertyChangedAsync;
            return instance;
        }

        private ValueElementDateTime CreateValueElementDateTime(Type propertyType, PropertyInfo property)
        {
            var data = (DateTime) property.GetValue(EncapsulatedDto, null);
            var dateAttribute = (DateAttribute) property.GetCustomAttribute(typeof(DateAttribute));
            DateTypes dateType;
            if (dateAttribute != null)
            {
                dateType = dateAttribute.GetDateType();
            }
            else
            {
                dateType = DateTypes.DateTime;
            }

            var instance = new ValueElementDateTime(property.Name,
                propertyType,
                dateType,
                data
            );
            instance.PropertyChanged += HandlePropertyChangedAsync;
            return instance;
        }

        private IValueElement CreateValueElementT(Type propertyType, PropertyInfo property)
        {
            Type genericType = typeof(ValueElementT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);

            instance.RawName = property.Name;
            instance.PropertyType = propertyType;

            PropertyInfo prop = instance.GetType().GetProperty("Data");
            prop.SetValue(instance, property.GetValue(EncapsulatedDto, null), null);
            instance.PropertyChanged += HandlePropertyChangedAsync;
            return instance;
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
                EncapsulatedDto.SetPropertyValue(castedSender.RawName, data);
            });
        }

        
    }
}
