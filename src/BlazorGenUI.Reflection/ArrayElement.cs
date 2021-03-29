using System.Collections;
using System.Collections.Generic;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class ArrayElement : IArrayElement 
    {
        private IEnumerable<object> Array { get; set; }
        private IList<IComplexElement> Items { get; set; } = new List<IComplexElement>();
        public ArrayElement(IEnumerable<object> array)
        {
            Array = array;
        }
        public string RawName { get; set; }
        public bool IsIgnored { get; set; }

        public IEnumerable<IComplexElement> GetItems()
        {
            foreach (var item in Array)
            {
                //osetri primitivne typy
                var complex = new ComplexElement(item);
                Items.Add(complex);
            }

            return Items;
        }
    }
}