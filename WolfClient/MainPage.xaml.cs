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
        
        private void OnInitClicked(object? sender, EventArgs e)
        {
            GitService gitService = new GitService();
            gitService.InitNewRepositoryAsync("");
        }
    }
}
