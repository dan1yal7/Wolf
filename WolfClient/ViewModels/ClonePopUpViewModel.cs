using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WolfClient.Contracts;

namespace WolfClient.ViewModels
{
    public partial class ClonePopUpViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CloneCommand))]
        private string repoUrl = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CloneCommand))]
        private string parentFolder = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CloneCommand))]
        private string repositoryName = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasError))]
        private string? errorMessage;

        public bool HasError => !string.IsNullOrEmpty(errorMessage);

        private readonly IPopupService _popupService;
        private readonly IGitService _gitService;

        public ClonePopUpViewModel(IPopupService popupService, IGitService gitService)
        {
            _popupService = popupService;
            _gitService = gitService;
        }

        [RelayCommand]
        async Task Cancel()
        {
            await _popupService.ClosePopupAsync(Shell.Current);
        }

        [RelayCommand]
        async Task BrowseFolder()
        {
            var result = await FolderPicker.Default.PickAsync(CancellationToken.None);
            if (result.IsSuccessful)
                ParentFolder = result.Folder.Path;
        }

        [RelayCommand(CanExecute = nameof(CanClone))]
        async Task Clone()
        {
            try
            {
                ErrorMessage = null;
                await _gitService.CloneAsync(RepoUrl, Path.Combine(ParentFolder, RepositoryName));
                await _popupService.ClosePopupAsync(Shell.Current);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        bool CanClone()
        {
            return !string.IsNullOrWhiteSpace(RepoUrl) &&
                   !string.IsNullOrWhiteSpace(ParentFolder) &&
                   !string.IsNullOrWhiteSpace(RepositoryName);
        }
    }
}
