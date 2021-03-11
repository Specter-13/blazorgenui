using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IValueElement : IBaseElement
    {

        string ElementName { get; set; }
        Type PropertyType { get; set; }

        event PropertyChangedEventHandler PropertyChanged;

    }
}
