using BlazorGenUI.Reflection.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorGenUI.Reflection.Services
{
    public static class ServicesConfiguration
    {
        public static void AddBlazorGenUIServices(this IServiceCollection services)
        {
            services.AddSingleton<ComponentService>();
            services.AddSingleton<LayoutProvider>();
            services.AddSingleton<ViewTemplateProvider>();

        }
    }
}