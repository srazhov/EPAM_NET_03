//-----------------------------------------------------------------------
// <copyright file="FundamentalsTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace FrameworkFundamentals.Tests
{
    using System.Collections;
    using NUnit.Framework;

    /// <summary>
    /// Test of the <see cref="Fundamentals"/> class
    /// </summary>
    [TestFixture]
    public class FundamentalsTest
    {
        /// <summary>Test of the <see cref="Fundamentals.MakeProperTitle(string, string)"/> method</summary>
        /// <param name="title">Title to change</param>
        /// <param name="exceptions">Exceptions that method will ignore</param>
        /// <returns>The proper title</returns>
        [TestCase("a clash of KINGS", "a an the of", ExpectedResult = "A Clash of Kings")]
        [TestCase("THE WIND IN THE WILLOWS", "The In", ExpectedResult = "The Wind in the Willows")]
        [TestCase("the quick brown fox", ExpectedResult = "The Quick Brown Fox")]
        public string MakeProperTitle(string title, string exceptions = "") => Fundamentals.MakeProperTitle(title, exceptions);

        /// <summary>Test of the <see cref="Fundamentals.AddOrChangeUrlParameter(string, string)"/> method</summary>
        /// <param name="url">URL to change</param>
        /// <param name="keyValueParameter">Key that changes the main URL</param>
        /// <returns>Modified URL</returns>
        [TestCase("www.example.com", "key=value", ExpectedResult = "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", ExpectedResult = "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]
        [TestCase("www.example.com?", "key=newValue", ExpectedResult = "www.example.com?key=newValue")]
        public string AddOrChangeUrlParameter(string url, string keyValueParameter) => Fundamentals.AddOrChangeUrlParameter(url, keyValueParameter);

        /// <summary>Test of the <see cref="Fundamentals.UniqueInOrder(IEnumerable)"/> method</summary>
        /// <param name="enumerable">Enumerable object</param>
        /// <returns>Sequence with unique order</returns>
        [TestCase("AAAABBBCCDAABBB", ExpectedResult = "ABCDAB")]
        [TestCase("ABBCcAD", ExpectedResult = "ABCcAD")]
        [TestCase("12233", ExpectedResult = "123")]
        [TestCase("", ExpectedResult = "")]
        [TestCase(new double[] { 1.1, 2.2, 2.2, 3.3 }, ExpectedResult = new double[] { 1.1, 2.2, 3.3 })]
        public IEnumerable UniqueInOrder_RemovesSame(IEnumerable enumerable) => Fundamentals.UniqueInOrder(enumerable);

        /// <summary>
        /// Test of the <see cref="Fundamentals.ReverseWords(string)"/> method
        /// </summary>
        /// <param name="text">Text to reverse</param>
        /// <returns>Reversed text</returns>
        [TestCase("", ExpectedResult = "")]
        [TestCase("The greatest victory is that which requires no battle", ExpectedResult = "battle no requires which that is victory greatest The")]
        public string ReverseWords_Test_ReturnStr_With_Reversed_Words_Order(string text) => Fundamentals.ReverseWords(text);

        /// <summary>
        /// Test of the <see cref="Fundamentals.GetSumOfTwoNumbers(string, string)"/> method
        /// </summary>
        /// <param name="first">First argument</param>
        /// <param name="second">Second argument</param>
        /// <returns>Merged longs in string type</returns>
        [TestCase("11096", "678904", ExpectedResult = "690000")]
        [TestCase("38814", "-5678", ExpectedResult = "33136")]
        [TestCase("Abs", "-71892", ExpectedResult = null)]
        [TestCase("12345", "-71892.294", ExpectedResult = null)]
        public string GetSumOfTwoNumbers_ReturnSumOfNumbers_InString(string first, string second) => Fundamentals.GetSumOfTwoNumbers(first, second);
    }
}