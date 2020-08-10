using System;

namespace Counter
{
    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;
        public Clock()
        {

            _seconds = new Counter("seconds");
            _minutes = new Counter("minutes");
            _hours = new Counter("hours");

        }

        public void Reset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();

        }
        public string ReadTime
        {
            get
            {
                return $"{_hours.Count}:{_minutes.Count}:{_seconds.Count}";
            }
        }
        public void Tick()
        {
            if (_seconds.Count < 59)
            {
                _seconds.Increment();

            } else
            {
                _seconds.Reset();
                if (_minutes.Count < 59)
                {
                    _minutes.Increment();
                } else
                {
                    _minutes.Reset();
                    if (_hours.Count == 23)
                    {
                        _hours.Reset();
                    }
                    else
                    {
                        _minutes.Increment();

                    }
                }
            }
        }
    }
}
