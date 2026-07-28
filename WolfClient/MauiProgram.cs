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
                .UseMauiCommunityToolkit(options =>
                {
                    // Прозрачная обёртка попапа — тёмную карточку рисует сам ContentView.
                    options.SetPopupDefaults(new DefaultPopupSettings
                    {
                        BackgroundColor = Colors.Transparent,
                        Padding = 0,
                        Margin = 0
                    });
                    options.SetPopupOptionsDefaults(new DefaultPopupOptionsSettings
                    {
                        CanBeDismissedByTappingOutsideOfPopup = false,
                        PageOverlayColor = Color.FromArgb("#99000000"),
                        Shape = null
                    });
                })
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
