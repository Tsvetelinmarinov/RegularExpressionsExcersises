/// <summary>
///  02.Race
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main()
        {
            List<string> participants = Console.ReadLine()!
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, double> racers = new();

            string input = Console.ReadLine()!;

            while (input != "end of race")
            {
                string name = string.Concat(
                    Regex.Matches(input, @"[A-Za-z]")
                        .Select(m => m.Value)
                );

                double distance = Regex.Matches(input, @"\d")
                    .Select(m => double.Parse(m.Value))
                    .Sum();

                if (participants.Contains(name))
                {
                    if (!racers.ContainsKey(name))
                    {
                        racers[name] = 0;
                    }

                    racers[name] += distance;
                }

                input = Console.ReadLine()!;
            }

            List<KeyValuePair<string, double>> topRacers = racers
                .OrderByDescending(r => r.Value)
                .Take(3)
                .ToList();

            string[] places = { "1st", "2nd", "3rd" };

            for (int i = 0; i < topRacers.Count; i++)
            {
                Console.WriteLine($"{places[i]} place: {topRacers[i].Key}");
            }
        }
    }
}
