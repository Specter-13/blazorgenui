using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
        public ComplexElement(object context, string ignoredFields, string pictureFields, IDictionary<string,int> order)
        {
            EncapsulatedDto = context;
            RawName = context.GetType().Name;
            IgnoredFields = ignoredFields;
            PictureFields = pictureFields;
            Order = order;
        }
        private IList<IBaseElement> Children { get; set; } = new List<IBaseElement>();
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }

        public IDictionary<string, int> Order { get; }
        public object EncapsulatedDto { get; set; }
        public string IgnoredFields { get; }
        public string PictureFields { get; }

        public IEnumerable<IBaseElement> GetChildren()
        {
            var listOfProperties = EncapsulatedDto.GetType().GetRuntimeProperties();
           
            if (Children.Count == 0)
            {
                foreach (var property in listOfProperties)
                {
                    
                    bool isIgnored = HasIgnore(property);

                    var propertyType = property.PropertyType;
                    if (propertyType.IsPrimitive || 
                        (propertyType == typeof(string) || propertyType == typeof(decimal) || propertyType == typeof(Guid))
                    )
                    {
                        //is generic
                        var instance = CreateValueElementT(propertyType, property);
                        instance.IsIgnored = isIgnored;
                        instance.IsPicture = HasPicture(property);
                        Children.Add(instance);
                    }
                    else if (propertyType == typeof(DateTime))
                    {
                        var instance = CreateValueElementDateTime(propertyType, property);
                        instance.IsIgnored = isIgnored;
                        Children.Add(instance);
                    }
                    else if (propertyType.IsEnum)
                    {
                        var instance = CreateValueElementEnumT(propertyType, property);
                        instance.IsIgnored = isIgnored;
                        Children.Add(instance);
                    }
                    //is array
                    else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                    {
                        var dto = property.GetValue(EncapsulatedDto);
                        //ask for opinion
                        if (dto != null)
                        {
                            IList objList = (IList)dto;
                            IEnumerable<object> collection = objList.Cast<object>();
                            var instance = new ArrayElement(collection);
                            instance.IsIgnored = isIgnored;
                            instance.RawName = property.Name;
                            Children.Add(instance);
                        }
                    }
                    //complex
                    else
                    {
                        var dto = property.GetValue(EncapsulatedDto, null);
                        if (dto != null)
                        {
                            var complex = new ComplexElement(dto);
                            complex.IsIgnored = isIgnored;
                            Children.Add(complex);
                        }
                    }

                }
            }

            //reorder
            if (Order != null) ReorderChildren();

            return Children;
        }

        private void ReorderChildren()
        {
            foreach (var item in Order)
            {
                var child = Children.FirstOrDefault(x =>
                    x.RawName.Equals(item.Key, StringComparison.InvariantCultureIgnoreCase));
                if (child != null)
                {
                    Children.Remove(child);
                    Children.Insert(item.Value, child);
                }
            }
        }

        private bool HasIgnore(PropertyInfo property)
        {
            bool isIgnored;
            if (IgnoredFields != null)
            {
                var r = new Regex(property.Name, RegexOptions.IgnoreCase);
                isIgnored = r.IsMatch(IgnoredFields);
            }
            else
            {
                isIgnored = GetPropertyAttribute<RenderIgnoreAttribute>(property) != null;
            }

            return isIgnored;
        }

        private bool HasPicture(PropertyInfo property)
        {
            bool isPicture;
            if (PictureFields != null)
            {
                var r = new Regex(property.Name, RegexOptions.IgnoreCase);
                isPicture = r.IsMatch(PictureFields);
            }
            else
            {
                isPicture = false;
                //add picture attribute
                // = GetPropertyAttribute<RenderIgnoreAttribute>(property) != null;
            }

            return isPicture;
        }


        private IValueElement CreateValueElementEnumT(Type propertyType, PropertyInfo property)
        {
            Type genericType = typeof(ValueElementEnumT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);
            instance.RawName = property.Name;
            instance.PropertyType = propertyType;

            var data = property.GetValue(EncapsulatedDto, null);
            var prop = instance.GetType().GetProperty("Data");
            prop.SetValue(instance, data, null);
            instance.RawData = data;
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

            var data = property.GetValue(EncapsulatedDto, null);
            var prop = instance.GetType().GetProperty("Data");

            prop.SetValue(instance, data, null);
            instance.RawData = data;
            instance.PropertyChanged += HandlePropertyChanged;
            return instance;
        }

        protected void HandlePropertyChanged(object sender, PropertyChangedEventArgs a)
        {
           
            var castedSender = (IValueElement) sender;
            var data = castedSender.GetPropertyValue("Data");
            EncapsulatedDto.SetPropertyValue(castedSender.RawName, data);
            
        }

        private T GetPropertyAttribute<T>(PropertyInfo prop) where T : class
        {
            var typeAttribute = prop
                .GetCustomAttributes(true)
                .ToList()
                .Find(p => p.GetType() == typeof(T)) as T;
            return typeAttribute;
        }
    }
}
