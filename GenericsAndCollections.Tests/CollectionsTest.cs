// <copyright file="CollectionsTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Tests
{
    using System;
    using GenericsAndCollections.Collections;
    using NUnit.Framework;

    /// <summary>Test of the custom generic collections</summary>
    [TestFixture]
    public class CollectionsTest
    {
        /// <summary>Test of the <see cref="Queue{T}"/> class</summary>
        [Test]
        public void QueueTest()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(15);
            queue.Enqueue(20);

            // foreach test
            foreach (var q in queue)
            {
                Console.WriteLine(q);
            }

            while (queue.TryDequeue(out var result))
            {
                Console.WriteLine("Current queue: " + result);
            }

            Assert.AreEqual(0, queue.Count);
        }

        /// <summary>Test of the <see cref="Stack{T}"/> class</summary>
        [Test]
        public void StackTest()
        {
            Stack<string> stack = new Stack<string>();

            stack.Push("Toma");
            stack.Push("Index");
            stack.Push("Alex");
            stack.Push("Michael");

            // Foreach test
            // Values must be reversed
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }

            while (stack.TryPop(out var result))
            {
                Console.WriteLine("Current stack: " + result);
            }

            Assert.AreEqual(0, stack.Count);
        }
    }
}