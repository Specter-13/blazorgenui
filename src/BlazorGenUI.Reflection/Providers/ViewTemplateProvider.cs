﻿using System;
using System.Collections.Generic;
using System.Text;
using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Providers
{
    public class ViewTemplateProvider
    {
        public ViewTemplateProvider()
        {


            _layoutDictionary = new Dictionary<ViewTemplate, (string assembly, string fullTypeName)>();
            _layoutDictionary[ViewTemplate.DetailViewTemplate] = ("BlazorGenUI.Components", "DetailViewTemplate");
            //_layoutDictionary[Layout.Wrap] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.WrapPanelLayout");
            //_layoutDictionary[Layout.Tabs] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.TabControlLayout");
            //_layoutDictionary[Layout.Border] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.BorderLayout");
            //_layoutDictionary[Layout.GroupBox] = ("Vortex.Presentation.Controls.Blazor", "Vortex.Presentation.Controls.Blazor.Layouts.GroupBoxLayout");
            //_layoutDictionary[Layout.Scroll] = ("PresentationFramework", "System.Windows.Controls.ScrollViewer");
            //_layoutDictionary[Layout.UniformGrid] = ("PresentationFramework", "System.Windows.Controls.Primitives.UniformGrid");

        }

        private readonly Dictionary<ViewTemplate, (string assembly, string fullTypeName)> _layoutDictionary;
        public (string assembly, string fullTypeName) GetTemplate(ViewTemplate viewTemplate)
        {
            return _layoutDictionary[viewTemplate];
        }
    }
}