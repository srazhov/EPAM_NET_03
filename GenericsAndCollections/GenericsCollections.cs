// <copyright file="GenericsCollections.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Static class that holds methods that does not have to be non-static
    /// </summary>
    public static class GenericsCollections
    {
        /// <summary>
        /// Gets the index of the first found key from an array
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="array">Array to look for</param>
        /// <param name="key">Key element</param>
        /// <returns>Index of the first found key. Otherwise, -1</returns>
        public static int BinarySearch<T>(T[] array, T key)
        {
            int left = 0;
            int right = array.Length;

            while(!(left >= right))
            {
                int mid = left + (right - left) / 2;
                if(array[mid].GetHashCode() == key.GetHashCode())
                {
                    return mid;
                }

                if(array[mid].GetHashCode() > key.GetHashCode())
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        /// <summary></summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IEnumerable<string> FrequencyOfWords(string text)
        {
            var words = text.ToLower().Split(' ', ',', '.', '-').Where(w => !string.IsNullOrWhiteSpace(w));

            while (words.Count() != 0)
            {
                var word = words.First();
                int count = words.Count(w => word == w);
                words = words.Where(w => w != word);

                if (count > 1)
                {
                    yield return $"{word} occur {count} times";
                }
            }
        }

        /// <summary>Iterates the Fibonacci number until the given maximum</summary>
        /// <param name="max">Max number</param>
        /// <returns>Max Fibonacci number that less or equal than given maximum</returns>
        public static IEnumerator<int> Fibonacci(int max)
        {
            int first = 1;
            int second = 1;
            int result = 0;

            while (result <= max) 
            {
                yield return result;
                result = first;
                first = second;
                second += result;
            }
        }

        /// <summary>
        /// Calculates a reverse polish notation
        /// </summary>
        /// <param name="polishNotation">Polish notation</param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>The result of the math operation</returns>
        public static int ReversePolishNotation(string polishNotation)
        {
            string[] notation = polishNotation.Split(' ').Where(note => !string.IsNullOrWhiteSpace(note)).ToArray();
            string[] availableOps = { "+", "-", "*", "/" };

            if (notation.Any(note => availableOps.Contains(note) && note.Length > 1))
            {
                throw new ArgumentException("There must always be the spaces between numbers and operations");
            }

            // Here is being used custom Collections.Stack<T> class
            Collections.Stack<int> stack = new Collections.Stack<int>();

            foreach(var note in notation)
            {
                if (availableOps.Contains(note))
                {
                    if(!stack.TryPop(out var second) || !stack.TryPop(out var first))
                    {
                        throw new ArgumentException();
                    }

                    stack.Push(MathOp(first, second, note));
                }
                else
                {
                    if (!int.TryParse(note, out int result))
                    {
                        throw new ArgumentException();
                    }

                    stack.Push(result);
                }
            }

            if(stack.Count != 1)
            {
                throw new ArgumentException();
            }

            return stack.Pop();
        }

        /// <summary>Calculates two operands with given operator</summary>
        /// <param name="first">First operand</param>
        /// <param name="second">Second operand</param>
        /// <param name="op">The operator</param>
        /// <returns>The result</returns>
        private static int MathOp(int first, int second, string op) 
        {
            return op switch
            {
                "+" => first + second,
                "-" => first - second,
                "*" => first * second,
                "/" => first / second,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}
