using WolfClient.ViewModels;

namespace WolfClient.Components;

public partial class ClonePopUp : ContentView
{
	public ClonePopUp(ClonePopUpViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
