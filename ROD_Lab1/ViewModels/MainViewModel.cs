using ROD_Lab1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROD_Lab1.ViewModels
{
    public class MainViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private HeatingModelSettings hms = new();

        private string _iActualSize;
        private string _jActualSize;
        private string _kActualSize;


        public string iActualSize
        {
            get { return _iActualSize; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _iActualSize = value;
                    OnPropertyChanged(nameof(iActualSize));
                }
            }
        }
        public string jActualSize
        {
            get { return _jActualSize; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _jActualSize = value;
                    OnPropertyChanged(nameof(jActualSize));
                }
            }
        }
        public string kActualSize
        {
            get { return _kActualSize; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _kActualSize = value;
                    OnPropertyChanged(nameof(kActualSize));
                }
            }
        }

        public MainViewModel()
        {
            iActualSize = $"{hms.iActualSize}";
            jActualSize = $"{hms.jActualSize}";
            kActualSize = $"{hms.kActualSize}";
        }
    }
}
