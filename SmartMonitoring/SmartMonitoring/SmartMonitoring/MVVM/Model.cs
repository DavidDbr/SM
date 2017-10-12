using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.MVVM
{
    class Model  
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string speed;
        public string rpm;
        public string Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
                OnPropertyChanged();
            }
        }

        public string Rpm
        {
            get
            {
                return rpm;
            }

            set
            {
                rpm = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}


