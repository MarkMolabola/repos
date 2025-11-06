using MonkeyFinderMVVM.ViewModel;

namespace MonkeyFinderMVVM
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MonkeysViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

      
    }

}
