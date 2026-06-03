namespace FinalProjApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new MainPage());
            window.Created += (s, e) => System.Diagnostics.Debug.WriteLine("Window created!");
            window.Activated += (s, e) => System.Diagnostics.Debug.WriteLine("Window activated!");
            return window;
        }
    }
}