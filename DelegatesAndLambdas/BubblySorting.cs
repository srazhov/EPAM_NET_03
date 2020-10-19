//-----------------------------------------------------------------------
// <copyright file="BubblySorting.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace DelegatesAndLambdas
{
    /// <summary>
    /// Bubbly sort an array with custom comparer
    /// </summary>
    public class BubblySorting
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BubblySorting"/> class
        /// </summary>
        /// <param name="sortingMethod">Sorting method</param>
        public BubblySorting(SortingMethodDelegate sortingMethod)
        {
            this.SortingMethod = sortingMethod;
        }

        /// <summary>Provides the way to sort the arrays</summary>
        /// <param name="first">First object</param>
        /// <param name="second">Second object</param>
        /// <returns>An answer to the swapping condition</returns>
        public delegate bool SortingMethodDelegate(int[] first, int[] second);

        /// <summary>
        /// The way the <see cref="BubblySorting"/> should sort the arrays
        /// </summary>
        public event SortingMethodDelegate SortingMethod;

        /// <summary>Sorts an array</summary>
        /// <param name="array">Array to sort</param>
        public void BubbleSort(int[][] array)
        {
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(0) - 1; k++)
                {
                    if (this.SortingMethod(array[k], array[k + 1]))
                    {
                        int[] temp = array[k];
                        array[k] = array[k + 1];
                        array[k + 1] = temp;
                    }
                }
            }
        }
    }
}
