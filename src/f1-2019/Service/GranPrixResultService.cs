using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class GranPrixResultService
    {
        private readonly IEnumerable<Driver> _drivers;

        public IEnumerable<Driver> DriversOrderedByTotalTime => OrderDriversByTotalTime();

        public IEnumerable<Driver> DriversOrderedByFastestLap => OrderDriversByFastestLap();

        public IEnumerable<Driver> DriversOrderedByAvarageSpeed => OrderDriversByAvarageSpeed();

        public GranPrixResultService(IEnumerable<LapEntry> laps)
        {
            _drivers = ParseDrivers(laps);
        }

        private IEnumerable<Driver> ParseDrivers(IEnumerable<LapEntry> lapEntries)
        {
            var drivers = lapEntries.Select(l => new Driver(l.DriverNumber, l.DriverName)).Distinct();
            
            drivers = drivers.Select(driver =>
            {
                var laps = lapEntries
                                 .Where(l => l.DriverNumber == driver.Number)
                                 .Select(l => new Lap(l.TimeOfDay, l.LapNumber, l.LapTime, l.AvarageSpeed));
                return new Driver(driver.Number, driver.Name, laps);
            });

            return drivers;
        }

        private IEnumerable<Driver> OrderDriversByTotalTime()
        {
            var drivers = _drivers.OrderBy(d => d.GetTotalTime())
                .Select((driver, position) => new Driver(driver.Number, driver.Name, ++position, driver.Laps));

            var firstTotalTime = drivers.First().GetTotalTime();

            return drivers.
                Select(driver => new Driver(driver.Number, driver.Name, driver.Position, driver.Laps, driver.GetTotalTime() - firstTotalTime));
        }

        private IEnumerable<Driver> OrderDriversByFastestLap()
        {
            return _drivers.OrderBy(d => d.GetFastestLap())
                .Select((driver, position) => new Driver(driver.Number, driver.Name, ++position, driver.Laps)); ;
        }

        private IEnumerable<Driver> OrderDriversByAvarageSpeed()
        {
            return _drivers.OrderByDescending(d => d.GetAvarageSpeed())
                .Select((driver, position) => new Driver(driver.Number, driver.Name, ++position, driver.Laps)); ;
        }
    }
}
