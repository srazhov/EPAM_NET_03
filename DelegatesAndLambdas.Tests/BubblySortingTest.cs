//-----------------------------------------------------------------------
// <copyright file="BubblySortingTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace DelegatesAndLambdas.Tests
{
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Test of the <see cref="BubblySorting"/> class
    /// </summary>
    [TestFixture]
    public class BubblySortingTest
    {
        /// <summary>Test of a delegate and an event</summary>
        [Test]
        public void BubbleSortTest_BySumOfArrays_GetsCustomComparer_ReturnsSortedMatrix()
        {
            BubblySorting.SortingMethodDelegate method = (int[] x, int[] y) =>
            {
                return x.Sum() < y.Sum();
            };

            BubblySorting bubble = new BubblySorting(method);

            int[][] input =
            {
                new int[] { 5, 9, 11 },
                new int[] { 9, 12, 41 },
                new int[] { 7, 2, 3, 10 }
            };

            int[][] expected =
            {
                new int[] { 9, 12, 41 },
                new int[] { 5, 9, 11 },
                new int[] { 7, 2, 3, 10 }
            };

            bubble.BubbleSort(input);
            Assert.AreEqual(expected, input);
        }

        /// <summary>Test of a delegate and an event</summary>
        [Test]
        public void BubbleSortTest_ByHighestValue_ReturnSortedMatrix()
        {
            BubblySorting.SortingMethodDelegate method = (int[] x, int[] y) =>
            {
                return x.Max() < y.Max();
            };

            BubblySorting bubble = new BubblySorting(method);

            int[][] input =
            {
                new int[] { 5, 9, 11 },
                new int[] { 9, 12, 41 },
                new int[] { 7, 2, 3, 10 }
            };

            int[][] expected =
            {
                new int[] { 9, 12, 41 },
                new int[] { 5, 9, 11 },
                new int[] { 7, 2, 3, 10 }
            };

            bubble.BubbleSort(input);
            Assert.AreEqual(expected, input);
        }
    }
}
