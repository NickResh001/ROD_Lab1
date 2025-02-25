using ROD_Lab1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ROD_Lab1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private HeatingModelSettings hms = new();

        #region Границы
        private string _A_i_weight;
        private string _A_j_weight;
        private string _A_free_weight;

        private string _AA_i_weight;
        private string _AA_j_weight;
        private string _AA_free_weight;

        private string _B_j_weight;
        private string _B_k_weight;
        private string _B_free_weight;

        private string _BB_j_weight;
        private string _BB_k_weight;
        private string _BB_free_weight;

        private string _C_i_weight;
        private string _C_k_weight;
        private string _C_free_weight;

        private string _CC_i_weight;
        private string _CC_k_weight;
        private string _CC_free_weight;

        public string A_i_weight
        {
            get { return _A_i_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _A_i_weight = value;
                    OnPropertyChanged(nameof(A_i_weight));
                }
            }
        }
        public string A_j_weight
        {
            get { return _A_j_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _A_j_weight = value;
                    OnPropertyChanged(nameof(A_j_weight));
                }
            }
        }
        public string A_free_weight
        {
            get { return _A_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _A_free_weight = value;
                    OnPropertyChanged(nameof(A_free_weight));
                }
            }
        }

        public string AA_i_weight
        {
            get { return _AA_i_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _AA_i_weight = value;
                    OnPropertyChanged(nameof(AA_i_weight));
                }
            }
        }
        public string AA_j_weight
        {
            get { return _AA_j_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _AA_j_weight = value;
                    OnPropertyChanged(nameof(AA_j_weight));
                }
            }
        }
        public string AA_free_weight
        {
            get { return _AA_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _AA_free_weight = value;
                    OnPropertyChanged(nameof(AA_free_weight));
                }
            }
        }

        public string B_k_weight
        {
            get { return _B_k_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _B_k_weight = value;
                    OnPropertyChanged(nameof(B_k_weight));
                }
            }
        }
        public string B_j_weight
        {
            get { return _B_j_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _B_j_weight = value;
                    OnPropertyChanged(nameof(B_j_weight));
                }
            }
        }
        public string B_free_weight
        {
            get { return _B_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _B_free_weight = value;
                    OnPropertyChanged(nameof(B_free_weight));
                }
            }
        }

        public string BB_k_weight
        {
            get { return _BB_k_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _BB_k_weight = value;
                    OnPropertyChanged(nameof(BB_k_weight));
                }
            }
        }
        public string BB_j_weight
        {
            get { return _BB_j_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _BB_j_weight = value;
                    OnPropertyChanged(nameof(BB_j_weight));
                }
            }
        }
        public string BB_free_weight
        {
            get { return _BB_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _BB_free_weight = value;
                    OnPropertyChanged(nameof(BB_free_weight));
                }
            }
        }

        public string C_k_weight
        {
            get { return _C_k_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _C_k_weight = value;
                    OnPropertyChanged(nameof(C_k_weight));
                }
            }
        }
        public string C_i_weight
        {
            get { return _C_i_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _C_i_weight = value;
                    OnPropertyChanged(nameof(C_i_weight));
                }
            }
        }
        public string C_free_weight
        {
            get { return _C_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _C_free_weight = value;
                    OnPropertyChanged(nameof(C_free_weight));
                }
            }
        }

        public string CC_k_weight
        {
            get { return _CC_k_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _CC_k_weight = value;
                    OnPropertyChanged(nameof(CC_k_weight));
                }
            }
        }
        public string CC_i_weight
        {
            get { return _CC_i_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _CC_i_weight = value;
                    OnPropertyChanged(nameof(CC_i_weight));
                }
            }
        }
        public string CC_free_weight
        {
            get { return _CC_free_weight; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _CC_free_weight = value;
                    OnPropertyChanged(nameof(CC_free_weight));
                }
            }
        }
        #endregion

        private string _iActualSize;
        private string _jActualSize;
        private string _kActualSize;

        private string _tau;
        private string _h;
        private string _a;
        private string _tmax;
        private bool _isStable;

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

        public string Tau
        {
            get { return _tau; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _tau = value;
                    OnPropertyChanged(nameof(Tau));
                }
            }
        }
        public string H
        {
            get { return _h; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _h = value;
                    OnPropertyChanged(nameof(H));
                }
            }
        }
        public string A
        {
            get { return _a; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _a = value;
                    OnPropertyChanged(nameof(A));
                }
            }
        }
        public string Tmax
        {
            get { return _tmax; }
            set
            {
                double temp;
                if (double.TryParse(value, out temp) || double.TryParse(value + "0", out temp))
                {
                    _tmax = value;
                    OnPropertyChanged(nameof(Tmax));
                }
            }
        }
        public bool IsStable
        {
            get { return _isStable; }
            set
            {
                _isStable = value;
                OnPropertyChanged(nameof(IsStable));
            }
        }

        public RelayCommand UpdateSettingsCommand { get; set; }

        public MainViewModel()
        {
            SettingsToProps();

            UpdateSettingsCommand = new RelayCommand(UpdateSettings);
        }
        private void SettingsToProps()
        {
            A_i_weight = $"{hms.A_i_weight}";
            A_j_weight = $"{hms.A_j_weight}";
            A_free_weight = $"{hms.A_free_weight}";
            AA_i_weight = $"{hms.AA_i_weight}";
            AA_j_weight = $"{hms.AA_j_weight}";
            AA_free_weight = $"{hms.AA_free_weight}";

            B_k_weight = $"{hms.B_k_weight}";
            B_j_weight = $"{hms.B_j_weight}";
            B_free_weight = $"{hms.B_free_weight}";
            BB_k_weight = $"{hms.BB_k_weight}";
            BB_j_weight = $"{hms.BB_j_weight}";
            BB_free_weight = $"{hms.BB_free_weight}";

            C_k_weight = $"{hms.C_k_weight}";
            C_i_weight = $"{hms.C_i_weight}";
            C_free_weight = $"{hms.C_free_weight}";
            CC_k_weight = $"{hms.CC_k_weight}";
            CC_i_weight = $"{hms.CC_i_weight}";
            CC_free_weight = $"{hms.CC_free_weight}";

            iActualSize = $"{hms.iActualSize}";
            jActualSize = $"{hms.jActualSize}";
            kActualSize = $"{hms.kActualSize}";

            Tau = $"{hms.tau}";
            H = $"{hms.h}";
            A = $"{hms.a}";
            Tmax = $"{hms.maxTime}";
            IsStable = hms.isStable;
        }
        private void PropsToSettings()
        {
            hms.A_i_weight = FromStringToDouble(A_i_weight);
            hms.A_j_weight = FromStringToDouble(A_j_weight);
            hms.A_free_weight = FromStringToDouble(A_free_weight);
            hms.AA_i_weight = FromStringToDouble(AA_i_weight);
            hms.AA_j_weight = FromStringToDouble(AA_j_weight);
            hms.AA_free_weight = FromStringToDouble(AA_free_weight);

            hms.B_k_weight = FromStringToDouble(B_k_weight);
            hms.B_j_weight = FromStringToDouble(B_j_weight);
            hms.B_free_weight = FromStringToDouble(B_free_weight);
            hms.BB_k_weight = FromStringToDouble(BB_k_weight);
            hms.BB_j_weight = FromStringToDouble(BB_j_weight);
            hms.BB_free_weight = FromStringToDouble(BB_free_weight);

            hms.C_i_weight = FromStringToDouble(C_i_weight);
            hms.C_k_weight = FromStringToDouble(C_k_weight);
            hms.C_free_weight = FromStringToDouble(C_free_weight);
            hms.CC_i_weight = FromStringToDouble(CC_i_weight);
            hms.CC_k_weight = FromStringToDouble(CC_k_weight);
            hms.CC_free_weight = FromStringToDouble(CC_free_weight);

            hms.iActualSize = FromStringToDouble(iActualSize);
            hms.jActualSize = FromStringToDouble(jActualSize);
            hms.kActualSize = FromStringToDouble(kActualSize);

            hms.tau = FromStringToDouble(Tau);
            hms.h = FromStringToDouble(H);
            hms.a = FromStringToDouble(A);
            hms.maxTime = FromStringToDouble(Tmax);

            SettingsToProps();
        }
        private double FromStringToDouble(string str)
        {
            double result = 0;
            if(!double.TryParse(str, out result))
            {
                if(!double.TryParse(str + "0", out result))
                {
                    return 0;
                }
            }
            return result;
        }


        public void UpdateSettings(object parameter)
        {
            PropsToSettings();
        }


    }
}
