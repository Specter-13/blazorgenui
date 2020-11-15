using System;
using BlazorGenUI.Components;
using BlazorGenUI.Reflection;

namespace ObjectsClassLibrary
{
    public  class TestDto : EntryBase
    {
        public string TestString { get; set; } = "ahoj";
        public int TestInteger { get; set; } = 5;
    }
}
