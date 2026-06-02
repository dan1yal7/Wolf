using CommunityToolkit.Maui.Storage;
using WolfClient.Contracts;
using WolfClient.Services;

namespace WolfClient
{
    public partial class MainPage : ContentPage
    {  

        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        #region eventhandlers

        private void OnFileClicked(object? sender, EventArgs e)
        {
            var button = sender as Button;
            FlyoutBase.GetContextFlyout(button);
        }
        private void OnCloneClicked(object? sender, EventArgs e)
        {
           
        }
        private void OnExitClicked(object? sender, EventArgs e)
        {
            
        }
        
        private async void OnInitClicked(object? sender, EventArgs e)
        {
            var result = await FolderPicker.Default.PickAsync(CancellationToken.None);

            if (result.IsSuccessful) 
            {
                string selectedPath = result.Folder.Path;
                GitService gitService = new GitService();
                gitService.InitNewRepositoryAsync(selectedPath);
            }
        }

        #endregion
    }
}
