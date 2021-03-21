using System;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Providers;

namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)
    ]
    public class ContainerAttribute : System.Attribute
    {
        private Layout _layout;

        public ContainerAttribute(Layout layout)
        {
            this._layout = layout;
        
        }

        public Layout GetLayout()
        {
            return _layout;

        }
    }
}