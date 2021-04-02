using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IComplexElement : IBaseElement
    {
        IEnumerable<IBaseElement> GetChildren();

        string IgnoredFields { get; }
        string PictureFields { get; }
        IDictionary<string, int> Order { get; }
        object EncapsulatedDto { get; set; }
    }
}
