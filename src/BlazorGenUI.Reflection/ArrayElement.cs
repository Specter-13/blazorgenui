using System.Collections;
using System.Collections.Generic;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class ArrayElement : IArrayElement 
    {
        internal IEnumerable<object> Array { get; set; }
        internal IList<IBaseElement> Items { get; set; } = new List<IBaseElement>();
        public ArrayElement(IEnumerable<object> array)
        {
            Array = array;
        }
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }

        public IEnumerable<IBaseElement> GetItems()
        {
            return Items;
        }
    }
}