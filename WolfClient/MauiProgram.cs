using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WolfClient.Components;
using WolfClient.Contracts;
using WolfClient.Services;
using WolfClient.ViewModels;

namespace WolfClient
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
                });

            builder.Services.AddSingleton<IGitService, GitService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransientPopup<ClonePopUp, ClonePopUpViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }   
}
