using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BlazorGenUI.Reflection.Annotations;

namespace BlazorGenUI.Reflection
{
    public class PropertyBaseData : INotifyPropertyChanged
    {
        private string _propertyName;
        private Type _propertyType;
        private object _propertyValue;
        public string PropertyName 
        { 
            get => _propertyName;
            set
            {
                _propertyName = value;
                OnPropertyChanged(nameof(PropertyName));
            }
        }
        public Type PropertyType
        {
            get => _propertyType;
            set
            {
                _propertyType = value;
                OnPropertyChanged(nameof(PropertyType));
            }
        }
        public object PropertyValue
        {
            get => _propertyValue;
            set
            {
                _propertyValue = value;
                OnPropertyChanged(nameof(PropertyValue));
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
