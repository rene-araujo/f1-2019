using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace f1_2019
{
    public class FileReader
    {
        private readonly IFormatProvider _formatProvider;

        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _formatProvider = new CultureInfo("pt-BR");
            _filePath = filePath;
        }

        public FileResult ReadFile()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_filePath) || !File.Exists(_filePath))
                    throw new FileLoadException();

                var fileLines = File.ReadAllLines(_filePath);

                var laps = ParseLaps(fileLines);

                return new FileResult(true, laps);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file, details: {ex.Message}");
            }

            return new FileResult(false, new List<LapEntry>());
        }

        private IEnumerable<LapEntry> ParseLaps(IEnumerable<string> lines)
        {
            foreach(var line in lines.Skip(1))
            {
                var lap = Regex.Matches(line, @"[^\s]+");

                var lapEntry = new LapEntry(timeOfDay: TimeSpan.ParseExact(lap[0].Value, @"hh\:mm\:ss\.fff", _formatProvider),
                                            driverNumber: lap[1].Value,
                                            driverName: lap[3].Value,
                                            lapNumber: int.Parse(lap[4].Value, _formatProvider),
                                            lapTime: TimeSpan.ParseExact(lap[5].Value, @"m\:ss\.fff", _formatProvider),
                                            avarageSpeed: decimal.Parse(lap[6].Value, _formatProvider)
                                           );
                yield return lapEntry;
            }
        }
    }
}
