using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Lap
    {
        public TimeSpan TimeOfDay { get; }

        public int Number { get; }

        public TimeSpan Time { get; }

        public decimal AvarageSpeed { get; }

        public Lap(TimeSpan timeOfDay, int number, TimeSpan time, decimal avarageSpeed)
        {
            TimeOfDay = timeOfDay;
            Number = number;
            Time = time;
            AvarageSpeed = avarageSpeed;
        }
    }
}
