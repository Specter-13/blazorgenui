using System;
using System.ComponentModel;

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
