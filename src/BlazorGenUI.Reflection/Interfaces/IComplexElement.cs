using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IComplexElement : IBaseElement
    {
        IEnumerable<IBaseElement> GetKids();
        string GetName();
    }
}
