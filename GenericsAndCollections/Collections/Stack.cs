// <copyright file="Stack.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Custom generic Stack class
    /// </summary>
    /// <typeparam name="T">Type of the Stack instance</typeparam>
    public class Stack<T> : IEnumerable<T> 
    {
        /// <summary>Holder of this stack items</summary>
        private T[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class
        /// </summary>
        public Stack()
        {
            array = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class
        /// </summary>
        /// <param name="arr">Fill the Stack with an array</param>
        public Stack(T[] arr)
        {
            array = arr;
        }

        /// <summary>Gets the count of stack items</summary>
        public int Count { get => array.Length; }

        /// <summary>
        /// Puts this item to the end
        /// </summary>
        /// <param name="item">A new item</param>
        public void Push(T item)
        {
            Array.Resize(ref array, Count + 1);
            array[^1] = item;
        }

        /// <summary>
        /// Gets the last item of this Stack and delets it
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">There is no items in this Stack</exception>
        /// <returns>Last item of this stack</returns>
        public T Pop()
        {
            if(TryPop(out T result))
            {
                return result;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Gets the last item of this stack but not deleting it
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">There is no items in this Stack</exception>
        /// <returns>Last item of this queue</returns>
        public T Peek()
        {
            if (TryPeek(out T result))
            {
                return result;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Tries to get the last item of this stack. Deletes if it was successful
        /// </summary>
        /// <param name="result">Result of getting the item</param>
        /// <returns>True, if Popping was successful. Otherwise, False</returns>
        public bool TryPop(out T result)
        {
            if(Count != 0)
            {
                result = array[^1];
                Array.Resize(ref array, Count - 1);
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Tries to get the last item of this stack. Doesn't delete if it was successful
        /// </summary>
        /// <param name="result">Result of getting the item</param>
        /// <returns>True, if peeking was successful. Otherwise, False</returns>
        public bool TryPeek(out T result)
        {
            if (Count != 0)
            {
                result = array[^1];
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>Does this stack contain the certain value</summary>
        /// <param name="item">Searching item</param>
        /// <returns>True, if it contains the item</returns>
        public bool Contains(T item)
        {
            return array.Contains(item);
        }

        /// <summary>
        /// Returns an Enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> object</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return array.Reverse().GetEnumerator();
        }

        /// <summary>
        /// Returns an Enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.Reverse().GetEnumerator();
        }
    }
}