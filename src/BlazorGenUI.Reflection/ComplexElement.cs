using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BlazorGenUI.Reflection.Attributes;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Exceptions;
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
        public ComplexElement(object context, 
            string ignoredFields, 
            string pictureFields, 
            IDictionary<string,int> order,
            IDictionary<string,string> labels)
        {
            EncapsulatedDto = context;
            RawName = context.GetType().Name;
            IgnoredFields = ignoredFields;
            PictureFields = pictureFields;
            Order = order;
            Labels = labels;
        }
        private IList<IBaseElement> Children { get; set; } = new List<IBaseElement>();
        public string AttributeName { get; set; }
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public bool IsValueElement { get; set; }

        public IDictionary<string, int> Order { get; set;}
        public IDictionary<string, string> Labels { get; set;}
        public object EncapsulatedDto { get; set; }
        public string IgnoredFields { get; set;}
        public string PictureFields { get;set; }

        private List<object> AttributeList { get; set; }
        public IEnumerable<IBaseElement> GetChildren()
        {
            var listOfProperties = EncapsulatedDto?.GetType().GetRuntimeProperties();

            if (Children.Count == 0 && listOfProperties != null)
            {
                foreach (var property in listOfProperties)
                {
                    AttributeList = property.GetCustomAttributes(true)?.ToList();

                    var rawName = property.Name;
                    var value = GetPropertyValue(property);
                    var child = CreateBaseElement(property.PropertyType, rawName, value);
                    if (child != null)
                    {
                        child.IsIgnored = HasIgnore(rawName);
                        child.AttributeName = GetCustomPropertyName(rawName);
                        Children.Add(child);
                    }

                }
            }

            //reorder
            if (Order != null) ReorderChildren();

            return Children;
        }

        private object GetPropertyValue(PropertyInfo property)
        {
            object value;
            if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
            {
                value = property.GetValue(EncapsulatedDto);
            }
            else
            {
                value = property.GetValue(EncapsulatedDto, null);
            }
            return value;
        }

        private void ReorderChildren()
        {
            foreach (var item in Order)
            {
                var child = Children.FirstOrDefault(x =>
                    x.RawName.Equals(item.Key, StringComparison.InvariantCultureIgnoreCase));
                if (child != null)
                {
                    var currentIndex = Children.IndexOf(child);
                    var newIndex = item.Value;
                    try
                    {
                        if (currentIndex < newIndex)
                        {
                            newIndex--;
                        }
                        Children.Remove(child);
                        Children.Insert(newIndex, child);
                    }
                    catch 
                    {
                        throw new IncorrectOrderException("BlazorGenUI Error! Cannot reorder elements! Check for correct order value!");
                    }
                }
                else
                {
                    throw new IncorrectOrderException("BlazorGenUI Error! Cannot reorder elements! Some of the provided elements cannot be found!");
                }
            }
        }

        protected void HandlePropertyChanged(object sender, PropertyChangedEventArgs a)
        {
            var castedSender = (IValueElement) sender;
            var data = castedSender.GetPropertyValue("Data");

            if (castedSender.PropertyType == typeof(DateTime))
            {
                HandleDateTimeOffsetChange(castedSender);
            }
            else
            {
                EncapsulatedDto.SetPropertyValue(castedSender.RawName, data);
            }
        }

        private void HandleDateTimeOffsetChange(IValueElement castedSender)
        {
            var castedSenderDateTime = (ValueElementDateTime) castedSender;
            if (castedSenderDateTime.IsDateTimeOffset)
            {
                var utcTime1 = DateTime.SpecifyKind(castedSenderDateTime.Data, DateTimeKind.Utc);
                DateTimeOffset utcTime2 = utcTime1;
                EncapsulatedDto.SetPropertyValue(castedSender.RawName, utcTime2);
            }
            else
            {
                EncapsulatedDto.SetPropertyValue(castedSender.RawName, castedSenderDateTime.Data);
            }
        }

        public IBaseElement CreateBaseElement(Type propertyType, string rawName, object value)
        {
            //is datetime
            if (propertyType == typeof(DateTime) ||
                propertyType == typeof(DateTimeOffset))
            {
                var instance = CreateValueElementDateTime(propertyType, rawName, value);
                return instance;
            }
            //is enum
            if (propertyType.IsEnum)
            {
                var instance = CreateValueElementEnumT(propertyType, rawName, value);
                return instance;
            }
            //is primitive
            if (propertyType.IsPrimitive ||
                     typeof(IComparable).IsAssignableFrom(propertyType))
            {
                //is generic
                var instance = CreateValueElementT(propertyType, rawName, value);
                return instance;
            }

            //is array
            if (typeof(IEnumerable).IsAssignableFrom(propertyType))
            {
                if (value != null)
                {
                    var instance = CreateArrayElement(rawName, value);
                    return instance;
                }

                return null;
            }

            //is complex
            if (value != null)
            {
                var complex = new ComplexElement(value);
                complex.IsIgnored = HasIgnore(rawName);
                return complex;
            }
            return null;
        }

        public ArrayElement CreateArrayElement(string rawName, object value)
        {
            IEnumerable<object> collection = ((IList)value).Cast<object>().ToList();
            var instance = new ArrayElement(collection)
            {
                RawName = rawName,
            };

            int i = 0;
            foreach (var item in collection)
            {
                var baseElement = CreateBaseElement(item.GetType(), $"{rawName}[{i}]", item);
                instance.Items.Add(baseElement);
                i++;
            }
            return instance;
        }

        public ValueElementDateTime CreateValueElementDateTime(Type propertyType, string rawName, object value)
        {
            DateTime data; 
            bool isOffset = false;
            if (propertyType == typeof(DateTimeOffset))
            {
                isOffset = true;
                propertyType = typeof(DateTime);
                var dataWithOffset = (DateTimeOffset)value;
                data = dataWithOffset.DateTime;
            }
            else
            {
                data = (DateTime)value;
            }

            
            DateTypes dateType;
            var dateAttribute = GetPropertyAttribute<DateAttribute>();
            if (dateAttribute != null)
            {
                
                dateType = dateAttribute.GetDateType();
            }
            else
            {
                dateType = DateTypes.DateTime;
            }

            var instance = new ValueElementDateTime(rawName,
                propertyType,
                dateType,
                data,
                isOffset
            );
            instance.IsValueElement = true;
            instance.PropertyChanged += HandlePropertyChanged;
            return instance;
        }

        public IValueElement CreateValueElementEnumT(Type propertyType, string rawName, object value)
        {
            Type genericType = typeof(ValueElementEnumT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);

            instance.RawName = rawName;
            instance.PropertyType = propertyType;
            instance.SetPropertyValue("Data", value);
            instance.RawData = value;
            instance.IsValueElement = true;
            instance.IsRadio = (GetPropertyAttribute<RadioButtonsEnumAttribute>() != null);
            instance.PropertyChanged += HandlePropertyChanged;

            return instance;
        }

        public IValueElement CreateValueElementT(Type propertyType, string rawName, object value)
        {
            Type genericType = typeof(ValueElementT<>).MakeGenericType(propertyType);
            var instance = (IValueElement) Activator.CreateInstance(genericType);

            instance.IsPicture = HasPicture(rawName);
            instance.RawName = rawName;
            instance.PropertyType = propertyType;
            instance.SetPropertyValue("Data", value);
            instance.RawData = value;
            instance.IsValueElement = true;
            instance.PropertyChanged += HandlePropertyChanged;

            return instance;
        }

        public T GetPropertyAttribute<T>() where T : class
        {
            return AttributeList?.Find(p => p.GetType() == typeof(T)) as T;;
        }

         private bool HasPicture(string rawName)
         {
             bool isPicture;
             if (PictureFields != null)
             {
                 var r = new Regex(rawName, RegexOptions.IgnoreCase);
                 isPicture = r.IsMatch(PictureFields);
             }
             else
             {
                 isPicture = GetPropertyAttribute<PictureAttribute>() != null;
             }
             return isPicture;
         }
         private bool HasIgnore(string rawName)
         {
             bool isIgnored;
             if (IgnoredFields != null)
             {
                 var r = new Regex(rawName, RegexOptions.IgnoreCase);
                 isIgnored = r.IsMatch(IgnoredFields);
             }
             else
             {
                 isIgnored = GetPropertyAttribute<RenderIgnoreAttribute>() != null;
             }

             return isIgnored;
         }

         private string GetCustomPropertyName(string rawName)
         {
             string value;
             if (Labels != null)
             {
                 if (Labels.TryGetValue(rawName, out value))
                 {
                     return value;
                 }

             }
             else
             {
                 var nameAttribute = GetPropertyAttribute<AttributeName>();
                 if(nameAttribute != null) return nameAttribute.GetCustomName();
             }
             return null;
         }

       
    }
}
