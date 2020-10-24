// <copyright file="LINQ_TaskTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace LINQ_Intro.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GenericsAndCollections.Collections;
    using NUnit.Framework;

    /// <summary>Test of the LINQ Queries"/></summary>
    [TestFixture]
    public class LINQ_TaskTest
    {
        /// <summary>Binary tree class instance</summary>
        private BinarySearchTree<Student> tree;

        /// <summary>Setup for the test class</summary>
        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree<Student>();

            tree.Insert(new Student("Jorsh Peg", "Using LINQ in C#", 15, 4));
            tree.Insert(new Student("Nicolas Cage", "Using LINQ in C#", 15, 2));
            tree.Insert(new Student("Sansa Stark", "Using LINQ in C#", 15, 3));
            tree.Insert(new Student("Magi Index", "Memorize everything", 20, 5));
            tree.Insert(new Student("Eddard Stark", "How to not lose your head", 21, 2));
            tree.Insert(new Student("Emilia Clarke", "How to become mother of Dragons", 23, 5));
            tree.Insert(new Student("Alex Cravchenko", "Using LINQ in C#", 15, 4));
            tree.Insert(new Student("Donald Trump", "Using LINQ in C#", 15, 2));
        }

        /// <summary>Test of the LINQ queries</summary>
        [Test]
        public void GetsTheBestStudents()
        {
            var greatPupils = from t in tree
                              where t.Assessment > 4
                              orderby t.TestDate
                              select t.Name;

            var expected = new string[] { "Magi Index", "Emilia Clarke" };
            this.Iterate(expected, greatPupils);
        }

        /// <summary>Test of the LINQ queries</summary>
        [Test]
        public void GetsTheLatestTest()
        {
            var latest = (from t in tree
                         orderby t.TestDate
                         descending
                         where t.Assessment > 3
                         select t.TestTitle).Take(3);

            var expected = new string[] { "How to become mother of Dragons", "Memorize everything", "Using LINQ in C#" };
            this.Iterate(expected, latest);
        }

        /// <summary>Method that iterates through a collection and checks if two collections are equal</summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="expected">Expected array</param>
        /// <param name="enumerable">Enumerable instance</param>
        private void Iterate<T>(T[] expected, IEnumerable<T> enumerable)
        {
            int index = 0;
            foreach (var e in enumerable)
            {
                Console.WriteLine(e);
                Assert.AreEqual(expected[index], e);
                index++;
            }
        }
    }
}