using System;
using System.Collections.Generic;
using System.Text;
using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)
    ]
    public class TemplateAttribute : System.Attribute
    {
        private string _name;
        private ViewTemplate _template;
        public TemplateAttribute(string templateName)
        {
            this._name = templateName;
        }
        public TemplateAttribute(ViewTemplate template)
        {
            this._template = template;
        }

        public ViewTemplate GetViewTemplate()
        {
            return _template;
        }
    }
}
