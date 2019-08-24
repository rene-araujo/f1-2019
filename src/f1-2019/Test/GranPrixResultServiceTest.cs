using Domain;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace f1_2019.Test
{
    [TestFixture]
    public class GranPrixResultServiceTest
    {
        private List<LapEntry> _lapEntries;

        [SetUp]
        public void SetUp()
        {
            _lapEntries = new List<LapEntry>
            {
                new LapEntry(TimeSpan.FromSeconds(500), "01", "Driver 01", 1, TimeSpan.FromSeconds(70), 40m),
                new LapEntry(TimeSpan.FromSeconds(580), "01", "Driver 01", 2, TimeSpan.FromSeconds(80), 35m),
                new LapEntry(TimeSpan.FromSeconds(680), "01", "Driver 01", 3, TimeSpan.FromSeconds(100), 30m),
                new LapEntry(TimeSpan.FromSeconds(535), "02", "Driver 02", 1, TimeSpan.FromSeconds(105), 27m),
                new LapEntry(TimeSpan.FromSeconds(585), "02", "Driver 02", 2, TimeSpan.FromSeconds(50), 70m),
                new LapEntry(TimeSpan.FromSeconds(645), "02", "Driver 02", 3, TimeSpan.FromSeconds(60), 65m),
            };
        }

        [Test]
        public void TestWinner()
        {
            var p1 = new GranPrixResultService(_lapEntries).DriversOrderedByTotalTime.First();

            Assert.That(p1.Number, Is.EqualTo("02"));
        }

        [Test]
        public void TestFastestLap()
        {
            var fastestLap = new GranPrixResultService(_lapEntries).DriversOrderedByFastestLap.First().GetFastestLap();

            Assert.That(fastestLap, Is.EqualTo(TimeSpan.FromSeconds(50)));
        }

        [Test]
        public void TestFastestAvarageSpeed()
        {
            var speed = new GranPrixResultService(_lapEntries).DriversOrderedByAvarageSpeed.First().GetAvarageSpeed();

            Assert.That(speed, Is.EqualTo(54m));
        }

        [Test]
        public void WinnerCompletedLaps()
        {
            var laps = new GranPrixResultService(_lapEntries).DriversOrderedByTotalTime.First().GetCompletedLaps();

            Assert.That(laps, Is.EqualTo(3));
        }

        [Test]
        public void WinnerTotalTime()
        {
            var totalTime = new GranPrixResultService(_lapEntries).DriversOrderedByTotalTime.First().GetTotalTime();

            Assert.That(totalTime, Is.EqualTo(TimeSpan.FromSeconds(215)));
        }

        [Test]
        public void NumberOfDrivers()
        {
            var driversCount = new GranPrixResultService(_lapEntries).DriversOrderedByTotalTime.Count();

            Assert.That(driversCount, Is.EqualTo(2));
        }

        [Test]
        public void Gap()
        {
            var p2 = new GranPrixResultService(_lapEntries).DriversOrderedByTotalTime.Where(driver => driver.Position == 2).First();

            Assert.That(p2.Gap, Is.EqualTo(TimeSpan.FromSeconds(35)));
        }
    }
}
