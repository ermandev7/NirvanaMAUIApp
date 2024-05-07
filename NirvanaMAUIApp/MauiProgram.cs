using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using NirvanaMAUIApp.Services;
using NirvanaMAUIApp.StateCurrent;
using System.Net.Http.Headers;
namespace NirvanaMAUIApp
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
            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();
            // En el método CreateMauiApp de tu archivo MauiProgram.cs
           

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<IAlmacenService, AlmacenService>();
            builder.Services.AddSingleton<ISucursalServices, SucursalService>();
            builder.Services.AddScoped<StateService>();
            builder.Services.AddSingleton<ILoginService , LoginService>();
          


#endif
           
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://192.168.1.145/CORE/api/")

            }) ;
            return builder.Build();
        }
    }
}
