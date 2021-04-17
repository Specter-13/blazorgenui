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

        public string AttributeName { get; set; }
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }
        public bool IsValueElement { get; set; }

        public IEnumerable<IBaseElement> GetItems()
        {
            if (Items.Count == 0 && Array != null)
            {
                foreach (var item in Array)
                {
                    var complex = new ComplexElement(item);
                    Items.Add(complex);
                }
            }

            return Items;
        }
    }
}