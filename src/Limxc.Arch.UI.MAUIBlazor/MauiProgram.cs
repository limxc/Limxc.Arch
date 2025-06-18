using Limxc.Arch.UI.MAUIBlazor.Services;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Limxc.Arch.Core;

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


            builder.Services.AddSingleton<DeviceSerialPortService>();

            // Add autofac
            builder.Services.AddAutofac(_builder =>
            {
                _builder.RegisterModule<InfraModule>();
                _builder.RegisterModule<CoreModule>();
                _builder.RegisterModule<AppModule>();
            });


            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBootstrapBlazor();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
