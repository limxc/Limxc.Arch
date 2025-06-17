using Autofac;
using Autofac.Extensions.DependencyInjection;
using Limxc.Arch.Core;
using Limxc.Arch.UI.MAUIBlazor.Services;
using Limxc.Arch.UI.Shared.Services;
using Microsoft.Extensions.Logging;

namespace Limxc.Arch.UI.MAUIBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the Limxc.Arch.UI.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            // Add autofac
            builder.Services.AddAutofac(_builder =>
            {
                _builder.RegisterModule<InfraModule>();
                _builder.RegisterModule<CoreModule>();
                _builder.RegisterModule<AppModule>();
            });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
