using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection.ValueElementTypes
{
    public class ValueElementT<T> : ValueElementBase, IValueElement 
    {
        private T _data;
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public bool IsPicture { get; set; }
        public Type PropertyType { get; set; }
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
