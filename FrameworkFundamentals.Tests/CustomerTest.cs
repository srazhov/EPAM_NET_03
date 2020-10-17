//-----------------------------------------------------------------------
// <copyright file="CustomerTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace FrameworkFundamentals.Tests
{
    using System.Globalization;
    using NUnit.Framework;

    /// <summary>
    /// Test of the <see cref="Customer"/> class
    /// </summary>
    [TestFixture]
    public class CustomerTest
    {
        /// <summary>Customer object</summary>
        private readonly Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

        /// <summary>Test of the <see cref="Customer.ToString(string, System.IFormatProvider)"/> method</summary>
        /// <param name="format">Format to work with</param>
        /// <returns>String representation of the <see cref="Customer"/> class</returns>
        [TestCase("A", ExpectedResult = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("T", ExpectedResult = "Customer record: +1 (425) 555-0100")]
        [TestCase("N", ExpectedResult = "Customer record: Jeffrey Richter")]
        public string ToString_ReturnsStringInChosenFormat(string format) => customer.ToString(format, new CultureInfo("en-US"));

        /// <summary>
        /// Test of the custom IFormatterProvider 
        /// </summary>
        /// <returns>To string</returns>
        [TestCase("A", ExpectedResult = "Customer record: Jeffrey Richter, 1/000/000.00, +1 (425) 555-0100")]
        public string CustomFormatProvider_Test(string arg) => customer.ToString(arg, new MyCustomFormat());
    }
}
