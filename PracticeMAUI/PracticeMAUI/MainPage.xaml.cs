namespace PracticeMAUI
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Navigate to the NewPage1
            await Shell.Current.GoToAsync("NewPage");
        }


    }

}
