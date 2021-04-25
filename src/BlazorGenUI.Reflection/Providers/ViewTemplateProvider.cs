using System.Collections.Generic;
using BlazorGenUI.Reflection.Enums;

namespace BlazorGenUI.Reflection.Providers
{
    public class ViewTemplateProvider
    {
        public ViewTemplateProvider()
        {

            _layoutDictionary = new Dictionary<Template, (string assembly, string fullTypeName)>();
            _layoutDictionary[Template.DetailView] = ("BlazorGenUI.Components", "DetailTemplateView");
            _layoutDictionary[Template.LoginView] = ("BlazorGenUI.Components", "LoginTemplateView");

        }

        private readonly Dictionary<Template, (string assembly, string fullTypeName)> _layoutDictionary;
        public (string assembly, string fullTypeName) GetTemplate(Template viewTemplate)
        {
            return _layoutDictionary[viewTemplate];
        }
    }
}
