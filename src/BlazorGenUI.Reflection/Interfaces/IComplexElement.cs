using System.Collections.Generic;

namespace BlazorGenUI.Reflection.Interfaces
{
    public interface IComplexElement : IBaseElement
    {
        IEnumerable<IBaseElement> GetChildren();

        string IgnoredFields { get; set;}
        string PictureFields { get;set; }
        IDictionary<string, int> Order { get; set;}
        object EncapsulatedDto { get; set; }
    }
}
