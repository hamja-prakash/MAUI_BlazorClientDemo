using BlazorSample.WebComponent.Models;
using BlazorSample.WebComponent.Repositories;
using BlazorSample.WebComponent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlazorSample.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
#if ANDROID && DEBUG
            Platforms.Android.DangerousTrustProvider.Register();
#endif

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddTransient<UserService>();
            builder.Services.AddTransient<UserRepository>();

            string conn = "Server=180.211.118.123;Initial Catalog=BlazorDemo;Persist Security Info=False;User ID=blazor;Password=psspl@123#;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
            builder.Services.AddDbContextFactory<DatabaseContext>(options => options.UseSqlServer(conn));
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }

    }
}