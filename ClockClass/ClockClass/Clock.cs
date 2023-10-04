using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockClass
{

    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;

        public Clock()
        { 
          _seconds = new Counter("secconds");
          _minutes = new Counter("minutes");
          _hours = new Counter("hours");
        }

        public void Tick()
        {
            _seconds.Increment();
            if (_seconds.Ticks == 60)
            {
                _minutes.Increment();
                _seconds.Reset();
                if (_minutes.Ticks == 60)
                {
                    _hours.Increment();
                    _minutes.Reset();
                    if (_hours.Ticks == 24)
                    {
                        Reset();
                    }
                }
            }
        }


        public void Reset()
        {
            _seconds.Reset();
            _minutes.Reset();
            _hours.Reset();
        }

        public string CurrentTime()
        {
            return $"{_hours.Ticks:D2}:{_minutes.Ticks:D2}:{_seconds.Ticks:D2}";
        }
    }
}