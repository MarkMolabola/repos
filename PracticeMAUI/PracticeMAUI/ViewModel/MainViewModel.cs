using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeMAUI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string text;
        
        public string Text
        {
            get { return text; }
            set 
            { 
                text = value; 
                OnPropertyChanged(nameof(Text));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string name) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



    }
}
