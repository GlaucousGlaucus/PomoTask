using PomoTask.Core;
using PomoTask.Store;
using System;
using System.Threading;

namespace PomoTask.MVVM.ViewModel
{
    class PomodoroViewModel : ObservableObject
    {

        private int _duration;
        private readonly TimerStore _timerStore;
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public double RemainingSeconds => _timerStore.RemainingTimeInSeconds;

        public RelayCommand ToggleTimerCommand { get; set; }


        public PomodoroViewModel() 
        {
            _timerStore = new TimerStore();
            Duration = 10;
            _timerStore.RemainingSecondsChanged += TimerStore_RemainingSecondsChanged;
            ToggleTimerCommand = new RelayCommand(o => {
                Console.WriteLine("Test");
                _timerStore.Start(Duration);
            });
        }

        private void TimerStore_RemainingSecondsChanged()
        {
            OnPropertyChanged();
        }
    }
}
