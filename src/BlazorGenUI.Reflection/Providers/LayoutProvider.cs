using System.Collections.Generic;
using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Providers
{
    public class LayoutProvider
    {
        public LayoutProvider()
        {


            _layoutDictionary = new Dictionary<LayoutTypes, (string assembly, string fullTypeName)>();
            _layoutDictionary[LayoutTypes.Wrap] = ("BlazorGenUI.Components", "WrapPanelLayout");
            _layoutDictionary[LayoutTypes.Grid2] = ("BlazorGenUI.Components", "UniformGridLayout");
            _layoutDictionary[LayoutTypes.Grid3] = ("BlazorGenUI.Components", "UniformGridLayout");
            _layoutDictionary[LayoutTypes.Grid4] = ("BlazorGenUI.Components", "UniformGridLayout");
            _layoutDictionary[LayoutTypes.Tabs] = ("BlazorGenUI.Components", "TabControlLayout");
          
            //_layoutDictionary[Layout.Wrap] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.WrapPanelLayout");

            //_layoutDictionary[Layout.Border] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.BorderLayout");
            //_layoutDictionary[Layout.GroupBox] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.GroupBoxLayout");
            //_layoutDictionary[Layout.Scroll] = ("PresentationFramework", "System.Windows.Controls.ScrollViewer");


        }

        private readonly Dictionary<LayoutTypes, (string assembly, string fullTypeName)> _layoutDictionary;
        public (string assembly, string fullTypeName) GetLayoutInfo(LayoutTypes layout)
        {
            return _layoutDictionary[layout];
        }
    }
}