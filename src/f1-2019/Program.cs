using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace f1_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid path.");
                Environment.Exit(-1);
            }

            var fileResult = new FileReader(args[0]).ReadFile();
            if (fileResult.Success == false)
            {
                Environment.Exit(-1);
            }

            var granPrixResult = new GranPrixResultService(fileResult.Lines);

            var drivers = granPrixResult.DriversOrderedByTotalTime;
            Console.WriteLine("GRAN PRIX RESULT");
            Console.WriteLine("POSITION | Nº | DRIVER | LAPS | TOTAL TIME | GAP");
            
            foreach (var driver in drivers)
                Console.WriteLine($"{driver.Position} | " +
                    $" {driver.Number} |" +
                    $" {driver.Name} |" +
                    $" {driver.GetCompletedLaps()} |" +
                    $" {driver.GetTotalTime().ToString(@"m\:ss\.fff")} |" +
                    $" {driver.Gap.ToString(@"m\:ss\.fff")}");

            Console.WriteLine("");

            drivers = granPrixResult.DriversOrderedByFastestLap;
            Console.WriteLine("FASTEST LAPS");
            Console.WriteLine("POSITION | Nº | DRIVER | FASTEST LAP");

            foreach (var driver in drivers)
                Console.WriteLine($"{driver.Position} | " +
                    $" {driver.Number} |" +
                    $" {driver.Name} |" +
                    $" {driver.GetFastestLap().ToString(@"m\:ss\.fff")}");

            Console.WriteLine("");

            drivers = granPrixResult.DriversOrderedByAvarageSpeed;
            Console.WriteLine("AVARAGE SPEED");
            Console.WriteLine("POSITION | Nº | DRIVER | AVARAGE SPEED");

            foreach (var driver in drivers)
                Console.WriteLine($"{driver.Position} | " +
                    $" {driver.Number} |" +
                    $" {driver.Name} |" +
                    $" {driver.GetAvarageSpeed().ToString("0.##")}");
        }
    }
}
