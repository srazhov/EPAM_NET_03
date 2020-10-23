// <copyright file="GenericsCollectionsTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Tests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Test of the <see cref="GenericsCollections"/> class
    /// </summary>
    [TestFixture]
    public class GenericsCollectionsTest
    {
        /// <summary>
        /// Test of the <see cref="GenericsCollections.BinarySearch{T}(T[], T)"/> class.
        /// <para>Test of the reference types</para>
        /// </summary>
        /// <param name="array">Array to look for</param>
        /// <param name="element">Key element</param>
        /// <returns>First index or -1</returns>
        [TestCase(new string[] { "A", "B", "C", "D" }, "C", ExpectedResult = 2)]
        [TestCase(new string[] { }, "1", ExpectedResult = -1)]
        public int BinarySearch_ReturnsReqItemIndex_OrMinus1(object[] array, object element) => GenericsCollections.BinarySearch(array, element);

        /// <summary>Test of the <see cref="GenericsCollections.FrequencyOfWords(string)"/> method</summary>
        /// <param name="text">Testing text</param>
        [TestCase("ƒай люд€м только заметить, что слова ран€т теб€, и тебе никогда не избавитьс€ от насмешек.ј если к тебе прилепили кличку, прими ее и сделай своим собственным именем. " +
            "“огда они не сумеют больше ранить теб€.")]
        [TestCase("Test of the test that is being used to test staff like testing test")]
        public void FrequensyOfWords(string text)
        {
            foreach (var word in GenericsCollections.FrequencyOfWords(text))
            {
                Console.WriteLine(word);
            }

            Assert.Pass();
        }

        /// <summary>
        /// Test of the <see cref="GenericsCollections.BinarySearch{T}(T[], T)"/> class.
        /// <para>Test of the struct integer type</para>
        /// </summary>
        /// <param name="array">Array to look for</param>
        /// <param name="element">Key element</param>
        /// <returns>First index or -1</returns>
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 4, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 }, 101, ExpectedResult = -1)]
        [TestCase(new int[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 }, 12, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 2, 4, 7, 8, 12, 15, 19, 24, 50, 69, 80, 100 }, 100, ExpectedResult = 12)]
        public int BinarySearch_IntTests(int[] array, int element) => GenericsCollections.BinarySearch(array, element);

        /// <summary>Test of the <see cref="GenericsCollections.Fibonacci(int)"/> method</summary>
        /// <param name="max">Max number</param>
        /// <param name="expected">Expected number</param>
        [TestCase(5, 5)]
        [TestCase(1000, 987)]
        [TestCase(120, 89)]
        public void Fibonacci_ReturnsFiboNumbersUntilMax(int max, int expected)
        {
            var fibo = GenericsCollections.Fibonacci(max);
            int maxElement = 0;

            while (fibo.MoveNext())
            {
                maxElement = fibo.Current;
                Console.WriteLine(maxElement);
            }

            Assert.AreEqual(expected, maxElement);
        }

        /// <summary>
        /// Test of the <see cref="GenericsCollections.ReversePolishNotation(string)"/> method
        /// </summary>
        /// <param name="input">Reversed polish notation</param>
        /// <returns>The result of the math operation</returns>
        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = 14)]
        [TestCase("4 3 6 - *", ExpectedResult = -12)]
        [TestCase("-21 3 + 6 /", ExpectedResult = -3)]
        [TestCase("2    5    +    4    *", ExpectedResult = 28)]
        public int ReversePolishNotation_ReturnsTheResultOfMath(string input) => GenericsCollections.ReversePolishNotation(input);

        /// <summary>
        /// Test of getting the exceptions from the <see cref="GenericsCollections.ReversePolishNotation(string)"/> method
        /// </summary>
        /// <param name="input">Invalid polish notations</param>
        [TestCase("1 3+")]
        [TestCase("1 3")]
        [TestCase("+ 1 5")]
        public void ReversePolishNotation_ExceptionTests(string input)
        {
            var exc = Assert.Throws<ArgumentException>(() => GenericsCollections.ReversePolishNotation(input));
            Assert.AreEqual(typeof(ArgumentException), exc.GetType());
        }
    }
}