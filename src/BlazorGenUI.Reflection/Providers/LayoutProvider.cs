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
            //_layoutDictionary[Layout.Wrap] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.WrapPanelLayout");
            //_layoutDictionary[Layout.Tabs] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.TabControlLayout");
            //_layoutDictionary[Layout.Border] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.BorderLayout");
            //_layoutDictionary[Layout.GroupBox] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.GroupBoxLayout");
            //_layoutDictionary[Layout.Scroll] = ("PresentationFramework", "System.Windows.Controls.ScrollViewer");
            //_layoutDictionary[Layout.UniformGrid] = ("PresentationFramework", "System.Windows.Controls.Primitives.UniformGrid");

        }

        private readonly Dictionary<LayoutTypes, (string assembly, string fullTypeName)> _layoutDictionary;
        public (string assembly, string fullTypeName) GetLayoutInfo(LayoutTypes layout)
        {
            return _layoutDictionary[layout];
        }
    }
}