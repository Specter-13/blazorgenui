using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)
    ]
    public class ContainerAttribute : System.Attribute
    {
        private LayoutTypes _layout;

        public ContainerAttribute(LayoutTypes layout)
        {
            this._layout = layout;
        
        }

        public LayoutTypes GetLayout()
        {
            return _layout;

        }
    }
}