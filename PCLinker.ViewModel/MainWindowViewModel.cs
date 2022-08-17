using PCLinker.BusinessModel;
using PCLinker.BusinessModel.interfaces;
using PCLinker.ViewModel.config;
using PCLinker.ViewModel.controls;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PCLinker.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        // Commit Test 1
        

        public MainWindowViewModel()
        {
           
            SliderOpacity = 100;
            
        }

        #region VM Command Method

       

        #endregion

        #region VM Property

        private double _windowOpacity;

        public double WindowOpacity
        {
            get
            {
                return _windowOpacity;
            }
            set
            {
                _windowOpacity = value;
                OnPropertyChanged(nameof(WindowOpacity));
            }
        }

        private double _sliderOpacity;

        public double SliderOpacity
        {
            get
            {
                return _sliderOpacity;
            }
            set
            {
                if (value >= 20)
                {
                    _sliderOpacity = value;
                    WindowOpacity = value / 100.0;
                    OnPropertyChanged(nameof(SliderOpacity));
                }
            }
        }

        private bool _mainWindowAlwaysTop;
        public bool MainWindowAlwaysTop {
            get
            {
                return _mainWindowAlwaysTop;
            }
            set
            {
                _mainWindowAlwaysTop = value;
                OnPropertyChanged(nameof(MainWindowAlwaysTop));
            }
        }

        private bool _isConnected;

        public bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                _isConnected = value;
                MainWindowAlwaysTop = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }

        public HeaderEditWindowViewModel HeaderEditWindowDataContext { get; set; } = new HeaderEditWindowViewModel();
        public ContentEditWindowViewModel ContentEditWindowDataContext { get; set; } = new ContentEditWindowViewModel();
        public IconEditWindowViewModel IconEditWindowDataContext { get; set; } = IconEditWindowViewModel.GetInstance(null);
        

        #endregion

        #region VM ICommand



        #endregion

    }
}
