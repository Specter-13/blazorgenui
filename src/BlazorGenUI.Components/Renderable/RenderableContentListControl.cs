using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BlazorGenUI.Reflection.Enums;
using BlazorGenUI.Reflection.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorGenUI.Components.Renderable
{
    public partial class RenderableContentListControl
    {
        [Parameter]
        public IEnumerable<object> ContextList { get; set; }
        [Parameter]
        public ArrayLayout Layout { get; set; }


        [Parameter]
        public string LgaNavigationPrefix { get; set; }

        [Parameter]
        public string LgaNavigationPropertyName { get; set; }
        [Parameter]
        public string LgaDisplayedPropertyName { get; set; }


        [Parameter]
        public PresentationType TcPresentation { get; set; }
        [Parameter]
        public string TcTabPageNameProperty { get; set; }


    }
}
