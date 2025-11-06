using System.ComponentModel.Design.Serialization;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;


namespace ApiFrontendDemo
{
    public partial class Form1 : Form
    {
        HttpClient moviesClient = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            moviesClient.BaseAddress = new Uri("http://localhost:5074/api/Movies");
        }

        private async void btnGetMovies_Click(object sender, EventArgs e)
        {
            var movies = await moviesClient.GetAsync(moviesClient.BaseAddress);
            if (movies.IsSuccessStatusCode)
            {
                var moviesList = await movies.Content.ReadFromJsonAsync<List<Movie>>();
                movieGrid.DataSource = moviesList;
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            using StringContent content = new(JsonSerializer.Serialize(new Movie
            {
                Id = 5,
                Title = " Something ",
                Director = "MeToo",
                ReleaseYear = 2000,
                Genre = "Scarry "
            }), System.Text.Encoding.UTF8, "application/json");
            using var response = moviesClient.PostAsync(moviesClient.BaseAddress, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Movie added successfully");
            }
            else
            {
                MessageBox.Show("Error " + response.StatusCode);
            }
        }

        private void btnGetWeather_Click(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.tomorrow.io/v4/weather/realtime?location=toronto&apikey=ZqC5zgJAqCFcIou60SIFDwd2aaSbEyMv");
            var response = httpClient.GetAsync(httpClient.BaseAddress).Result;
            Root root = response.Content.ReadFromJsonAsync<Root>().Result;
            if (response.IsSuccessStatusCode)
            {
                WeatherBox.Text = $"Temperature: {root.data.values.temperature}\nHumidity: {root.data.values.humidity}\nWind Speed: {root.data.values.windSpeed}";
            }
            else
            {
                MessageBox.Show("Error: " + response.StatusCode);
            }


        }
    }
}
