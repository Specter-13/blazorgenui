using System;
using System.Collections.Generic;
using BlazorGenUI.Components;
using BlazorGenUI.Reflection;
using BlazorGenUI.Reflection.Interfaces;


namespace ObjectsClassLibrary
{
    public  class TestDto : IRenderableComponent
    {
        public string TestString { get; set; }
        public int TestInteger { get; set; }

        //public bool TestBool { get; set; }
        //public TestEntity Entity { get; set; }
        //public List<string> ListOgStrings { get; set; }
        //public List<int> ListOfIntegers { get; set; }
        //public DateTime TestDate { get; set; }
    }
}
