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

        }

        private readonly Dictionary<LayoutTypes, (string assembly, string fullTypeName)> _layoutDictionary;
        public (string assembly, string fullTypeName) GetLayoutInfo(LayoutTypes layout)
        {
            return _layoutDictionary[layout];
        }
    }
}