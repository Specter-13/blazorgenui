using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection.ValueElementTypes
{
    public class ValueElementDateTime : ValueElementBase, IValueElement

    {

        public ValueElementDateTime(string rawName, 
            Type propertyType, 
            DateTypes dateType,
            DateTime data,
            bool isOffset)
        {
            RawName = rawName;
            PropertyType = propertyType;
            DateType = dateType;
            _data = data;
            RawData = data;
            IsDateTimeOffset = isOffset;
        }

        private DateTime _data;
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public Type PropertyType { get; set; }
        public bool IsPicture { get; set; }
        public bool IsDateTimeOffset { get; set; }
        public object RawData { get; set; }
        public DateTypes DateType { get; set; }


        public DateTime Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        
    }
}
