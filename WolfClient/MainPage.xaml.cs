using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Maui.Controls.Shapes;
using WolfClient.Contracts;
using WolfClient.ViewModels;

namespace WolfClient
{
    public partial class MainPage : ContentPage
    {
        private readonly IGitService _gitService;
        private readonly IPopupService _popupService;

        public MainPage(IGitService gitService, IPopupService popupService)
        {
            InitializeComponent();
            _gitService = gitService;
            _popupService = popupService;
        }

        #region eventhandlers

        private void OnFileClicked(object? sender, EventArgs e)
        {
            var button = sender as Button;
            FlyoutBase.GetContextFlyout(button);
        }
        private async void OnCloneClicked(object? sender, EventArgs e)
        {
            var options = new PopupOptions
            {
                CanBeDismissedByTappingOutsideOfPopup = false,
                PageOverlayColor = Color.FromArgb("#99000000"),
                Shape = new RoundRectangle
                {
                    CornerRadius = new CornerRadius(10),
                    Fill = Color.FromArgb("#2D2D30"),
                    Stroke = Color.FromArgb("#3F3F46"),
                    StrokeThickness = 1
                }
            };

            await _popupService.ShowPopupAsync<ClonePopUpViewModel>(this, options);
        }
        private void OnExitClicked(object? sender, EventArgs e)
        {
            
        }
        
        private async void OnInitClicked(object? sender, EventArgs e)
        {
            var result = await FolderPicker.Default.PickAsync(CancellationToken.None);

            if (!result.IsSuccessful)
                return;

            string selectedPath = result.Folder.Path;

            try
            {
                await _gitService.InitNewRepositoryAsync(selectedPath);
                await DisplayAlert("Success", "Repository initialized", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        #endregion
    }
}
