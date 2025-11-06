using MonkeyFinderMVVM.ViewModel;

namespace MonkeyFinderMVVM;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}