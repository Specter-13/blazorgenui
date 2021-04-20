using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct)
    ]
    public class TemplateAttribute : System.Attribute
    {
        private string _name;
        private Template _template;
        public TemplateAttribute(string templateName)
        {
            this._name = templateName;
        }
        public TemplateAttribute(Template template)
        {
            this._template = template;
        }

        public Template GetViewTemplate()
        {
            return _template;
        }
    }
}
