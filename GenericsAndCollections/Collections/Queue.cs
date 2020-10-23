// <copyright file="Queue.cs" company="EPAM">
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
    /// Custom generic Queue class
    /// </summary>
    /// <typeparam name="T">Type of the queue instance</typeparam>
    public class Queue<T> : IEnumerable<T> 
    {
        /// <summary>Holder of this queue members</summary>
        private T[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class
        /// </summary>
        public Queue()
        {
            array = new T[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class
        /// </summary>
        /// <param name="arr">Fill the queue with an array</param>
        public Queue(T[] arr)
        {
            array = arr;
        }

        /// <summary>Gets the count of queue members</summary>
        public int Count { get => array.Length; }

        /// <summary>
        /// Gets the first member of this queue and delets it
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">There is no members in this queue</exception>
        /// <returns>First member in this queue</returns>
        public T Dequeue()
        {
            if (TryDequeue(out T result))
            {
                return result;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Puts this item to the eng
        /// </summary>
        /// <param name="item">A new item</param>
        public void Enqueue(T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = item;
        }

        /// <summary>
        /// Gets the first member of this queue but not deleting it
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">There is no members in this queue</exception>
        /// <returns>First member in this queue</returns>
        public T Peek()
        {
            if(TryPeek(out T result))
            {
                return result;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Tries to get the first member of this queue. Doesn't delete if it was successful
        /// </summary>
        /// <param name="output">Result of getting the item</param>
        /// <returns>True, if peeking was successful. Otherwise, False</returns>
        public bool TryPeek(out T output)
        {
            if(array.Length != 0)
            {
                output = array[0];
                return true;
            }

            output = default;
            return false;
        }

        /// <summary>
        /// Tries to get the first member of this queue. Deletes if it was successful
        /// </summary>
        /// <param name="output">Result of getting the item</param>
        /// <returns>True, if Dequeue was successful. Otherwise, False</returns>
        public bool TryDequeue(out T output)
        {
            if (array.Length != 0)
            {
                output = array[0];
                array = array.Where((val, index) => index != 0).ToArray();
                return true;
            }

            output = default;
            return false;
        }

        /// <summary>Does this queue contain the certain value</summary>
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
            return ((IEnumerable<T>)array).GetEnumerator();
        }

        /// <summary>
        /// Returns an Enumerator that iterates through a collection
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }
}