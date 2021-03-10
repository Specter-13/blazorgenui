using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class PropertyBaseData : IPropertyBaseData
    {
        public IEntryBase Instance { get; set; }

        public string Name { get; set; }
        public Type PropertyType { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public object Data { get; set; }
    }
}
