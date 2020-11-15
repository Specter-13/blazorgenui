using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Fasterflect;

namespace BlazorGenUI.Reflection
{
    public class ReflectionLogic
    {
        public IList<PropertyBaseData> GetAllProperties(EntryBase context)
        {
            var listOfProperties = context.GetType().GetProperties();
            var propertyBaseDataList = new List<PropertyBaseData>();
            Type type = typeof(PropertyBaseData);
            
            foreach (var property in listOfProperties)
            {
                var baseProperty = new PropertyBaseData()
                {
                    PropertyName = property.Name,
                    PropertyType = property.PropertyType,
                    PropertyValue = property.GetValue(context, null)
                };
                propertyBaseDataList.Add(baseProperty);
            }

            return propertyBaseDataList;
            //var propValue = context.GetType().GetProperty("TestString").GetValue(context, null);
        }

      
    }
}
