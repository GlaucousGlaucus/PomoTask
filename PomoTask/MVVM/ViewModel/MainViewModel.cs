using PomoTask.Core;
using PomoTask.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomoTask.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand PomoViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }

        public PomodoroViewModel PomoVm { get; set; }

        private Object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }

        }


        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            PomoVm = new PomodoroViewModel(); 
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVm;
            });

            PomoViewCommand = new RelayCommand(o =>
            {
                CurrentView = PomoVm;
            });
        }
    }
}
