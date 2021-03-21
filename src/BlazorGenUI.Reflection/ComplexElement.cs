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
        public ComplexElement(object context)
        {
            EncapsulatedDto = context;
            RawName = context.GetType().Name;
        }
        private IList<IBaseElement> Children { get; set; } = new List<IBaseElement>();
        public string RawName { get; set; }

        public object EncapsulatedDto { get; set; }

        public IEnumerable<IBaseElement> GetChildren()
        {
            var listOfProperties = EncapsulatedDto.GetType().GetRuntimeProperties();
     
            if (Children.Count == 0)
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
                        Children.Add(instance);
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        var instance = CreateValueElementDateTime(propertyType, property);
                        Children.Add(instance);
                    }
                    else if (propertyType.IsEnum)
                    {
                        var instance = CreateValueElementEnumT(propertyType, property);
                        Children.Add(instance);
                    }
                    //complex  (consider arrays)
                    else
                    {
                       var dto = property.GetValue(EncapsulatedDto, null);
                       if (dto != null)
                       {
                           var complex = new ComplexElement(dto);
                           Children.Add(complex);
                       }
                    }

                }
            }
            return Children;
        }

        private IValueElement CreateValueElementEnumT(Type propertyType, PropertyInfo property)
        {
            Type genericType = typeof(ValueElementEnumT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);
            instance.RawName = property.Name;
            instance.PropertyType = propertyType;

            PropertyInfo prop = instance.GetType().GetProperty("Data");
            prop.SetValue(instance, property.GetValue(EncapsulatedDto, null), null);
            instance.PropertyChanged += HandlePropertyChanged;
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
            instance.PropertyChanged += HandlePropertyChanged;
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
            instance.PropertyChanged += HandlePropertyChanged;
            return instance;
        }

        protected void HandlePropertyChanged(object sender, PropertyChangedEventArgs a)
        {
           
            var castedSender = (IValueElement) sender;
            var data = castedSender.GetPropertyValue("Data");
            EncapsulatedDto.SetPropertyValue(castedSender.RawName, data);
            
        }

        
    }
}
