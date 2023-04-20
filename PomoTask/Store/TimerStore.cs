using System;
using System.Timers;

namespace PomoTask.Store
{
    public class TimerStore
    {

        private readonly Timer _timer;
        private DateTime _endTime;
        public event Action RemainingSecondsChanged;

        public double RemainingTimeInSeconds => TimeSpan.FromTicks(_endTime.Ticks).TotalSeconds - TimeSpan.FromTicks(DateTime.Now.Ticks).TotalSeconds;

        public TimerStore()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnRemainingSecondsChanged();
        }

        private void OnRemainingSecondsChanged()
        { 
            RemainingSecondsChanged?.Invoke();
        }

        public void Start(int durationInSeconds)
        {
            _timer.Start();
            _endTime = DateTime.Now.AddSeconds(durationInSeconds);
            OnRemainingSecondsChanged();
        }
    }
}
