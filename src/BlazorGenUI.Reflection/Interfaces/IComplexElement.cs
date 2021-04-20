using System.Collections.Generic;

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
