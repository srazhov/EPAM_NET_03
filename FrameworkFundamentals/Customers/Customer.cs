//-----------------------------------------------------------------------
// <copyright file="Customer.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace FrameworkFundamentals
{
    using System;
    using System.Globalization;

    /// <summary>Customer class</summary>
    public class Customer : IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class
        /// </summary>
        /// <param name="name">Name of the customer</param>
        /// <param name="contactPhone">Customer's phone</param>
        /// <param name="revenue">Customer's revenue</param>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            this.Name = name;
            this.ContactPhone = contactPhone;
            this.Revenue = revenue;
        }

        /// <summary>Gets the name of a customer</summary>
        public string Name { get; }

        /// <summary>Gets the contact phone of a customer</summary>
        public string ContactPhone { get; }

        /// <summary>Gets the revenue of a customer</summary>
        public decimal Revenue { get; }

        /// <summary>Converts this class to string</summary>
        /// <returns>String interpretation</returns>
        public override string ToString()
        {
            return ToString("A", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Converts this class to string
        /// </summary>
        /// <param name="format">Available: A, T, N</param>
        /// <param name="formatProvider">Format provider to work with</param>
        /// <returns>String interpretation</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "A";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            return format switch
            {
                "A" => string.Format(formatProvider, "Customer record: {0}, {1:#,##.00}, {2}", Name, Revenue, ContactPhone),
                "T" => $"Customer record: {ContactPhone}",
                "N" => $"Customer record: {Name}",
                _ => throw new ArgumentException($"The {format} format is not supported"),
            };
        }
    }
}
