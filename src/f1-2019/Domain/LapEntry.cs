using System;

namespace Domain
{
    public class LapEntry
    {
        public TimeSpan TimeOfDay { get; }

        public string DriverNumber { get; }

        public string DriverName { get; }

        public int LapNumber { get; }

        public TimeSpan LapTime { get; }

        public decimal AvarageSpeed { get; }

        public LapEntry(TimeSpan timeOfDay, string driverNumber, string driverName, int lapNumber, TimeSpan lapTime, decimal avarageSpeed)
        {
            TimeOfDay = timeOfDay;
            DriverNumber = driverNumber;
            DriverName = driverName;
            LapNumber = lapNumber;
            LapTime = lapTime;
            AvarageSpeed = avarageSpeed;
        }

        public override bool Equals(object obj)
        {
            return obj is LapEntry entry &&
                   TimeOfDay.Equals(entry.TimeOfDay) &&
                   DriverNumber == entry.DriverNumber &&
                   DriverName == entry.DriverName &&
                   LapNumber == entry.LapNumber &&
                   LapTime.Equals(entry.LapTime) &&
                   AvarageSpeed == entry.AvarageSpeed;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TimeOfDay, DriverNumber, DriverName, LapNumber, LapTime, AvarageSpeed);
        }
    }
}
