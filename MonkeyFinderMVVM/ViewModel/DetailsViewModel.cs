using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeyFinderMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyFinderMVVM.ViewModel
{
    [QueryProperty("Monkey", "Monkey")]
    public partial class DetailsViewModel : BaseViewModel
    {
        IMap map;
        public DetailsViewModel(IMap map)
        {
            Title = "Monkey Details";
            this.map = map;
        }
        [ObservableProperty]
        Monkey monkey;

        [RelayCommand]

        async Task OpenMapAsync()

        {

            try

            {

                await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions

                {

                    Name = Monkey.Name,

                    NavigationMode = NavigationMode.Driving

                });

            }

            catch (Exception ex)

            {

                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");

            }

        }



    }
}
