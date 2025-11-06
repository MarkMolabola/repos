namespace ScoreCalculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int totalScore = 0;
        float averageScore = 0.0f;


        public MainPage()
        {
            InitializeComponent();
        }

       private void OnAddScoreClicked(object sender, EventArgs e)
        {
            
            if()
            {

            }
            else 
            {
                DisplayAlert("Invalid Input", "Please enter a valid integer score.", "OK");
            }

        }
        private void OnClearClicked(object sender, EventArgs e)
        {
            count = 0;
            totalScore = 0;
            averageScore = 0.0f;
            lblScoreTotal.Text = "0";
            lblScoreCount.Text = "0";
            lblAverageScore.Text = "0.00";

        }
        private void OnExitClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

        }
    }

}
