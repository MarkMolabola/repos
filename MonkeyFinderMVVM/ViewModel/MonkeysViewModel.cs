using CommunityToolkit.Mvvm.Input;
using MonkeyFinderMVVM.Models;
using MonkeyFinderMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinderMVVM.ViewModel
{
    //ViewModel for mokeys on MainPage
     public partial class MonkeysViewModel: BaseViewModel
    {
        MonkeyService monkeyService;
        IConnectivity connectivity;
        IGeolocation geolocation;
        public ObservableCollection<Monkey> Monkeys { get; set; } = new ObservableCollection<Monkey>(); //not putting observable property since its already instantiated with new

        public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
        {
            Title = "Monkey Finder";
            this.connectivity = connectivity;
            this.geolocation = geolocation;
            this.monkeyService = monkeyService;
        }

        [RelayCommand]

        async Task GetMonkeyAsync()
        {
            if (IsBusy) return;
            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!", "Please check your internet and try again", "OK");
                    return;

                }
                IsBusy = true;
                var monkeys = await monkeyService.GetMonkeys();
                if (Monkeys.Count != 0)
                {
                    Monkeys.Clear();
                }
                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }


        }

        [RelayCommand]
        async Task GetClosestMonkey()
        {
            if (IsBusy || Monkeys.Count == 0)
            {
                await Shell.Current.DisplayAlert("Alert", "Please wait until the monkeys are loaded", "OK");
                return;
            }

            try
            {
                var location = await geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Unable to get location", "OK");
                    return;
                }
                var first = Monkeys.OrderBy(m => location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Miles)).FirstOrDefault();
                if (first != null)
                {
                    await Shell.Current.DisplayAlert("Closest Monkey", $"{first.Name} is located at {first.Location}", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }

        }
        
        
        
        [RelayCommand]
        async Task GoToDetailsAsync(Monkey monkey)

        {

            if (monkey == null) return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object> { {"Monkey", monkey } });

        }

    }
}
