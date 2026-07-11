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

        // "The current visible page" — это ContentPage внутри Shell, а не сам Shell.
        private static Page? CurrentPage => Shell.Current?.CurrentPage;

        [RelayCommand]
        async Task Cancel()
        {
            if (CurrentPage is { } page)
                await _popupService.ClosePopupAsync(page);
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
                errorMessage = null;
                await _gitService.CloneAsync(RepoUrl, Path.Combine(ParentFolder, RepositoryName));

                if (CurrentPage is { } page)
                    await _popupService.ClosePopupAsync(page);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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
