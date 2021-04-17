using System;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection.ValueElementTypes
{
    public class ValueElementEnumT<T> : ValueElementBase, IValueElement
    {
        

        private T _data;
        public string AttributeName { get; set; }
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public bool IsValueElement { get; set; }
        public Type PropertyType { get; set; }

        public bool IsPicture { get; set; }
        public bool IsRadio { get; set; }

        public object RawData { get; set; }


        public T Data
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