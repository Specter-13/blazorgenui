using System.Collections;
using System.Collections.Generic;
using BlazorGenUI.Reflection.Interfaces;

namespace BlazorGenUI.Reflection
{
    public class ArrayElement : IArrayElement 
    {
        private IEnumerable List { get; set; }
        public ArrayElement(IEnumerable array)
        {
            List = array;
        }
        public string RawName { get; set; }
    }
}