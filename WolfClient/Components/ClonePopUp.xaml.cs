using CommunityToolkit.Maui.Views;
using WolfClient.ViewModels;

namespace WolfClient.Components;

public partial class ClonePopUp : Popup
{
	public ClonePopUp(ClonePopUpViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
