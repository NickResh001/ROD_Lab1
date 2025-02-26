using ROD_Lab1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Collections.ObjectModel;

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
        private HeatingModeling3d solver;

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

        private WriteableBitmap _currentImage;
        private WriteableBitmap[] _images;
        private int _sliderValue;
        private int _sliderCount;
        private int _sliderMax;
        private bool _isParallel;
        private double _execTime;
        public WriteableBitmap CurrentImage
        {
            get { return _currentImage; }
            set
            {
                _currentImage = value;
                OnPropertyChanged(nameof(CurrentImage));
            }
        }
        
        public int SliderValue
        {
            get => _sliderValue;
            set
            {
                if (_sliderValue != value)
                {
                    _sliderValue = value;
                    OnPropertyChanged(nameof(SliderValue));
                    UpdateBitmap();
                }
            }
        }
        public int SliderCount
        {
            get => _sliderCount;
            set
            {
                if (_sliderCount != value)
                {
                    _sliderCount = value;
                    _sliderMax = value - 1;
                    OnPropertyChanged(nameof(SliderCount));
                    OnPropertyChanged(nameof(SliderMax));
                }
            }
        }
        public int SliderMax
        {
            get => _sliderMax;
            set
            {
                if (_sliderMax != value)
                {
                    _sliderMax = value;
                    OnPropertyChanged(nameof(SliderMax));
                }
            }
        }
        public bool IsParallel
        {
            get => _isParallel;
            set
            {
                if (_isParallel != value)
                {
                    _isParallel = value;
                    OnPropertyChanged(nameof(IsParallel));
                }
            }
        }
        public double ExecTime
        {
            get { return _execTime; }
            set
            {
                _execTime = value;
                OnPropertyChanged(nameof(ExecTime));
            }
        }
        public RelayCommand UpdateSettingsCommand { get; set; }
        public RelayCommand SolveCommand { get; set; }

        public MainViewModel()
        {
            UpdateSettingsCommand = new RelayCommand(UpdateSettings);
            SolveCommand = new RelayCommand(Solve);
            SliderCount = 10;
            ExecTime = 0;
            SettingsToProps();
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
        private void UpdateBitmap()
        {
            CurrentImage = _images[SliderValue];
        }
        private double GetMax()
        {
            List<double> maxs = [];
            maxs.Add(hms.u[0][0][0]);
            maxs.Add(hms.u[0][0][hms.kSize - 1]);
            maxs.Add(hms.u[0][hms.jSize - 1][0]);
            maxs.Add(hms.u[0][hms.jSize - 1][hms.kSize - 1]);
            maxs.Add(hms.u[hms.iSize - 1][0][0]);
            maxs.Add(hms.u[hms.iSize - 1][0][hms.kSize - 1]);
            maxs.Add(hms.u[hms.iSize - 1][hms.jSize - 1][0]);
            maxs.Add(hms.u[hms.iSize - 1][hms.jSize - 1][hms.kSize - 1]);
            return maxs.Max();
        }

        public void UpdateSettings(object parameter)
        {
            PropsToSettings();
        }
        public void Solve(object parameter)
        {
            solver = new();
            if (IsParallel)
                solver.SolveParallel(hms);
            else
                solver.Solve(hms);
            hms = solver.st;
            ExecTime = hms.execTime;

            var tmp = solver.GetMinAndMax();
            HeatMapService map = new(tmp.min, tmp.max, SliderCount);
            _images = map.CreateHeatMap(hms.u, hms.iSize, hms.jSize, hms.kSize);
            UpdateBitmap();
        }

    }
}
