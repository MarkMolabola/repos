using Assignment_12._3._2_CRUDappMAUI.ViewModels;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Assignment_12._3._2_CRUDappMAUI
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

     
    }

}
