/// <summary>
///  03.SoftUniBarIncome
/// </summary>

using System;

namespace _03.SoftUniBarIncome
{
    /// <summary>
    ///  Defines simple order with customer, product, qunatity of the product
    ///  and product price
    /// </summary>
    internal class Order
    {
        //Customer
        private string? customer;

        //Product name
        private string? product;

        //Quantity of the product
        private int quantity;

        //Product price
        private double price;


        /// <summary>
        ///  Get or set the customer name
        /// </summary>
        public string? Customer
        {
            get => customer;
            set
            {
                ArgumentNullException.ThrowIfNullOrEmpty(value);

                customer = value;
            }
        }

        /// <summary>
        ///  Get or set product name
        /// </summary>
        public string? Product
        {
            get => product;
            set
            {
                ArgumentNullException.ThrowIfNullOrEmpty(value);
                product = value;
            }
        }

        /// <summary>
        ///  Get or set the product quantity
        /// </summary>
        public int Quantity
        {
            get => quantity;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                quantity = value;
            }
        }

        /// <summary>
        ///  Get or set the price of the product
        /// </summary>
        public double Price
        {
            get => price;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                price = value;
            }
        }
    }
}
