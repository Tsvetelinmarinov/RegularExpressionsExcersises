/// <summary>
///  03.SoftUniBarIncome
/// </summary>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main()
        {
            List<Order> orders = new();
            string pattern = @"%(?<Name>[A-Z][a-z]+)%<(?<Product>\w+)>\|(?<Count>\d+)\|(?<Price>\d+\.\d+)\$";
            string def = Console.ReadLine()!;

            while (def != "end of shift")
            {
                bool isValidOrder = Regex.IsMatch(def, pattern);
                if (isValidOrder)
                {
                    Match currentDef = Regex.Match(def, pattern);

                    Order currentOrder = new()
                    {
                        Customer = currentDef.Groups["Name"].Value,
                        Product = currentDef.Groups["Product"].Value,
                        Quantity = int.Parse(currentDef.Groups["Count"].Value),
                        Price = double.Parse(currentDef.Groups["Price"].Value)
                    };

                    orders.Add(currentOrder);

                    Console.WriteLine(
                        $"{currentOrder.Customer}: {currentOrder.Product} - {currentOrder.Quantity * currentOrder.Price:F2}"
                    );
                }

                def = Console.ReadLine()!;
            }

            double sum = default;
            foreach (Order order in orders)
            {
                sum += order.Price * order.Quantity;
            }

            Console.WriteLine($"Total income: {sum:F2}");
        }
    }
}
