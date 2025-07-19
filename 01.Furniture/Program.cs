/// <summary>
///  01.Furniture
/// </summary>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main()
        {          
            Dictionary<string, double> furnitures = new();
            double sum = default;
            string pattern = @"(?i)>>(?<Furniture>[A-Za-z][A-Za-z]+)<<(?<Price>\d+[.]*(?:\d+)*)!(?<Quantity>\d+)";

            string def = Console.ReadLine()!;

            while (def != "Purchase")
            {
                bool isValid = Regex.IsMatch(def, pattern);

                if (isValid)
                {
                    Match current = Regex.Match(def, pattern);

                    string furnitureType = current.Groups["Furniture"].Value;
                    double price = double.Parse(current.Groups["Price"].Value);
                    int quantity = int.Parse(current.Groups["Quantity"].Value);

                    if (!furnitures.ContainsKey(furnitureType))
                    {
                        furnitures.Add(furnitureType, price * quantity);
                    }
                    else
                    {
                        furnitures[furnitureType] += price * quantity;
                    }
                }

                def = Console.ReadLine()!;
            }

            foreach (KeyValuePair<string, double> pair in furnitures)
            {
                sum += pair.Value;
            }

            Console.WriteLine("Bought furniture:");

            foreach (KeyValuePair<string, double> pair in furnitures)
            {
                Console.WriteLine(pair.Key);
            }

            Console.WriteLine($"Total money spend: {sum:F2}");
        }
    }
}
