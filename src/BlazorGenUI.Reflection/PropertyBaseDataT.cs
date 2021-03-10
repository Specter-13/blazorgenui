using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BlazorGenUI.Reflection.Annotations;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class PropertyBaseDataT<T> : IPropertyBaseData , INotifyPropertyChanged
    {
        public IEntryBase Instance { get; set; }

        private T _data;
        public string Name { get; set; }
        public Type PropertyType { get; set; }

        public T Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
