using System.Collections.Generic;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IArrayElement : IBaseElement
    {
        IEnumerable<IComplexElement> GetItems();
    }
}