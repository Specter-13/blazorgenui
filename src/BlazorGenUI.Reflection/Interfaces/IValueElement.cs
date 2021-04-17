using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IValueElement : IBaseElement
    {

        Type PropertyType { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
        bool IsPicture { get; set; }
        bool IsRadio { get; set; }
        object RawData { get; set; }

    }
}
