using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Driver
    {
        public string Number { get; }

        public string Name { get; }

        public int Position { get; }

        public IEnumerable<Lap> Laps { get; }

        public TimeSpan Gap { get; }

        public Driver(string number, string name, int position, IEnumerable<Lap> laps, TimeSpan gap)
        {
            Number = number;
            Name = name;
            Position = position;
            Laps = laps;
            Gap = gap;
        }

        public Driver(string number, string name, int position, IEnumerable<Lap> laps)
        {
            Number = number;
            Name = name;
            Position = position;
            Laps = laps;
        }
        public Driver(string number, string name, IEnumerable<Lap> laps)
        {
            Number = number;
            Name = name;
            Laps = laps;
        }

        public Driver(string number, string name)
        {
            Number = number;
            Name = name;
        }

        public TimeSpan GetFastestLap()
        {
            return Laps.Min(l => l.Time);
        }

        public TimeSpan GetTotalTime()
        {
            var sum = TimeSpan.Zero;

            foreach(var lap in Laps)
                sum = sum.Add(lap.Time);

            return sum;
        }

        public decimal GetAvarageSpeed()
        {
            var sum = Laps.Sum(l => l.AvarageSpeed);
            return sum / Laps.Count();
        }

        public int GetCompletedLaps()
        {
            return Laps.Max(l => l.Number);
        }

        public override bool Equals(object obj)
        {
            return obj is Driver driver &&
                   Number == driver.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number);
        }
    }
}
