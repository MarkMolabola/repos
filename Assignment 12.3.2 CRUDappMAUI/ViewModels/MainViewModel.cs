using Assignment_12._3._2_CRUDappMAUI.Services;
using Assignment_12._3._2_CRUDappMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Assignment_12._3._2_CRUDappMAUI.ViewModels
{

    public partial class MainViewModel : ObservableObject
    {
        GuardianCRUD guardianCRUD;
        ChildCRUD childCRUD;


        public MainViewModel(GuardianCRUD guardianCRUD, ChildCRUD childCRUD)
        {
            this.guardianCRUD = guardianCRUD;
            this.childCRUD = childCRUD;
        }

        //[RelayCommand]
        //private async void Add()
        //{
        //    if (string.IsNullOrWhiteSpace(Text))
        //    {
        //        await App.Current.MainPage.DisplayAlert("Error", "Please enter a valid task", "OK");
        //        return;
        //    }
        //    else
        //    {
        //        if (connectivity.NetworkAccess == NetworkAccess.Internet)
        //        {
        //            Items.Add(Text);
        //            Text = string.Empty;
        //        }
        //        else
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", "No internet connection. Please try again later.", "OK");
        //        }
        //    }

        //}
        //[RelayCommand]
        //private void Delete(string s)
        //{
        //    if (Items.Contains(s))
        //    {
        //        Items.Remove(s);
        //    }
        //}
    }
}
