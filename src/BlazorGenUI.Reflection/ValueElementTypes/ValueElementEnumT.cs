using System;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection.ValueElementTypes
{
    public class ValueElementEnumT<T> : ValueElementBase, IValueElement
    {
        

        private T _data;
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public Type PropertyType { get; set; }

        public object RawData { get; set; }
        //public DateTypes DateType { get; set; }


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