// <copyright file="BinarySearchTreeTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Tests.BinaryCollection
{
    using System;
    using System.Collections.Generic;
    using GenericsAndCollections.Collections;
    using NUnit.Framework;

    /// <summary>
    /// Test of the <see cref="BinarySearchTree{T}"/> class
    /// </summary>
    [TestFixture]
    public class BinarySearchTreeTest
    {
        /// <summary>Test of the <see cref="BinarySearchTree{T}.Insert(T)"/> method</summary>
        [Test]
        public void BinarySearchTree_InsertCountAndSearchTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Insert(8);

            tree.Insert(3);
            tree.Insert(10);

            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(14);

            tree.Insert(13);
            tree.Insert(7);
            tree.Insert(4);

            // Check count of this tree
            Assert.AreEqual(9, tree.Count);

            var a = tree.Search(6);
            var b = tree.Search(5);

            // Searching for tree
            Assert.AreEqual(6, a.Value);
            Assert.AreEqual(null, b);

            tree.Clear();
            Assert.AreEqual(0, tree.Count);
        }

        /// <summary>Test of the <see cref="BinarySearchTree{T}"/> custom comparison method</summary>
        [Test]
        public void BinarySearchTree_StringDefaultComparisonTest()
        {
            Comparer<string> comparer = Comparer<string>.Create(
                (string x, string y) => 
                {
                    if (x != null && y != null)
                    {
                        return x.CompareTo(y) * -1;
                    }
                    else if (x == null && y == null)
                    {
                        return 0;
                    }

                    // Null is greater than value
                    return x == null ? 1 : -1;
                });

            BinarySearchTree<string> tree = new BinarySearchTree<string>(comparer);
            tree.Insert(null);
            tree.Insert(null);
            tree.Insert("B");
            tree.Insert("A");

            Assert.That(tree.LeftBranch.Value == "B");
            Assert.That(tree.RightBranch.Value == null);
        }

        /// <summary>Test of the <see cref="BinarySearchTree{T}"/> default comparator</summary>
        [Test]
        public void BinarySearchTree_CustomBookDefaultComparisonTest()
        {
            BinarySearchTree<CustomBook> tree = new BinarySearchTree<CustomBook>();

            tree.Insert(new CustomBook("Kono Subarashii Sekai ni Skukufuku wo!", 128));
            tree.Insert(new CustomBook("Kono Subarashii Sekai ni Skukufuku wo!", 140));
            tree.Insert(new CustomBook("451 degrees fahrenheit", 128));
            tree.Insert(new CustomBook("Game of Thrones", 936));

            Assert.AreEqual(tree.RightBranch.Value, new CustomBook("Kono Subarashii Sekai ni Skukufuku wo!", 140));
            Assert.AreEqual(tree.LeftBranch.Value, new CustomBook("451 degrees fahrenheit", 128));
            Assert.AreEqual(tree.RightBranch.RightBranch.Value, new CustomBook("Game of Thrones", 936));
        }

        /// <summary>Test of the <see cref="BinarySearchTree{T}"/> class with the custom point struct</summary>
        [Test]
        public void BinarySearchTree_CustomStructComparisonTest()
        {
            Comparer<CustomPoint> comparer = Comparer<CustomPoint>.Create(
                (CustomPoint x, CustomPoint y) =>
                {
                    if (x.X == y.X && x.Y == y.Y)
                    {
                        return 0;
                    }
                    else if (x.X + x.Y > y.X + y.Y)
                    {
                        return 1;
                    }

                    return -1;
                });

            BinarySearchTree<CustomPoint> tree = new BinarySearchTree<CustomPoint>(comparer);

            tree.Insert(new CustomPoint(0, 1));
            tree.Insert(new CustomPoint(1, 1));
            tree.Insert(new CustomPoint(4, 7));
            tree.Insert(new CustomPoint(8, 1));
            tree.Insert(new CustomPoint(5, 6));

            Assert.AreEqual(tree.RightBranch.Value, new CustomPoint(1, 1));
            Assert.AreEqual(tree.RightBranch.RightBranch.LeftBranch.Value, new CustomPoint(8, 1));
        }

        /// <summary>Test of the <see cref="BinarySearchTree{T}"/> sorting methods</summary>
        [Test]
        public void BinarySearchTree_TraversingTest()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(6);
            tree.Insert(8);

            int[] direct = { 4, 2, 1, 3, 5, 7, 6, 8 };
            int[] reverse = { 1, 3, 2, 6, 8, 7, 5, 4 };
            int[] transverse = { 1, 2, 3, 4, 5, 6, 7, 8 };

            Iterate(direct, tree.Direct());
            Console.WriteLine("-------------------");
            Iterate(reverse, tree.Reverse());    
            Console.WriteLine("-------------------");
            Iterate(transverse, tree.Transverse());    
        }

        /// <summary>Simple private method that iterates through the collection</summary>
        /// <param name="array">Checking array</param>
        /// <param name="enumerable">IEnumerable object</param>
        private static void Iterate(int[] array, IEnumerable<int> enumerable)
        {
            int index = 0;
            foreach (var branch in enumerable)
            {
                Console.WriteLine(branch);
                Assert.AreEqual(array[index], branch);
                index++;
            }

            Assert.AreEqual(array.Length, index);
        }
    }
}
