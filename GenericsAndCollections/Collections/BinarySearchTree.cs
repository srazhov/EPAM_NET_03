// <copyright file="BinarySearchTree.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Collections
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>The Binary tree class</summary>
    /// <typeparam name="T">Any type that can be compared to each other</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        /// <summary>Comparator that compares values in binary tree</summary>
        private readonly IComparer<T> comparer;

        /// <summary>True, if its value has ever be modified</summary>
        private bool hasValue;

        /// <summary>Left branch</summary>
        private BinarySearchTree<T> left;

        /// <summary>Right branch</summary>
        private BinarySearchTree<T> right;

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class</summary>
        /// <exception cref="System.ArgumentException"></exception>
        public BinarySearchTree()
        {
            comparer = Comparer<T>.Default;
            try
            {
                comparer.Compare(Value, default);
            }
            catch
            { 
                throw new System.ArgumentException("If the comparer is set to Default, type T must be implemented by IComparable");
            }
        }

        /// <summary>Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class</summary>
        /// <param name="comparer">Custom comparer</param>
        public BinarySearchTree(IComparer<T> comparer) => this.comparer = comparer;

        /// <summary>Gets the count of items in this branch</summary>
        public int Count 
        {
            get
            {
                if (!hasValue)
                {
                    return 0;
                }

                return Direct().Count();
            }
        }

        /// <summary>Gets the value of this branch</summary>
        public T Value { get; protected set; }

        /// <summary>Gets the left branch of this tree</summary>
        public BinarySearchTree<T> LeftBranch { get => left; }

        /// <summary>Gets the right branch of this tree</summary>
        public BinarySearchTree<T> RightBranch { get => right; }

        /// <summary>
        /// Inserts the item in the tree
        /// </summary>
        /// <param name="item">Inserting item</param>
        public void Insert(T item)
        {
            if (!hasValue)
            {
                Value = item;
                hasValue = true;
                return;
            }

            BinarySearchTree<T> temp = this;
            ref BinarySearchTree<T> current = ref temp;

            while (current != null)
            {
                if (comparer.Compare(current.Value, item) > 0)
                {
                    // this.value > item
                    current = ref current.left;
                }
                else
                {
                    current = ref current.right;
                }
            }

            current = new BinarySearchTree<T>(comparer);
            current.Insert(item);
        }

        /// <summary>Searches one specified key from this tree</summary>
        /// <param name="key">Key value</param>
        /// <returns><see cref="BinarySearchTree{T}"/> object if found. Otherwise, null</returns>
        public BinarySearchTree<T> Search(T key)
        {
            BinarySearchTree<T> current = this;
            while (current != null)
            {
                int comp = comparer.Compare(current.Value, key);
                if (comp == 0)
                {
                    return current;
                }
                else if (comp > 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            return null;
        }

        /// <summary>Clears this binary tree.</summary>
        public void Clear()
        {
            left = null;
            right = null;
            Value = default;
            hasValue = false;
        }

        /// <summary>Gets the <see cref="IEnumerable{T}"/> that sorted the Preorder way</summary>
        /// <returns><see cref="IEnumerable{T}"/> object</returns>
        public IEnumerable<T> Direct() => GetCertainOrder(this, -1);

        /// <summary>Gets the <see cref="IEnumerable{T}"/> that sorted the Inorder way</summary>
        /// <returns><see cref="IEnumerable{T}"/> object</returns>
        public IEnumerable<T> Transverse() => GetCertainOrder(this, 0);

        /// <summary>Gets the <see cref="IEnumerable{T}"/> that sorted the Postorder way</summary>
        /// <returns><see cref="IEnumerable{T}"/> object</returns>
        public IEnumerable<T> Reverse() => GetCertainOrder(this, 1);

        /// <summary>String representation of this object</summary>
        /// <returns>To string</returns>
        public override string ToString()
        {
            string[] result =
            {
                isNull(Value),
                left == null ? "null" : isNull(left.Value),
                right == null ? "null" : isNull(right.Value)
            };

            return $"{result[0]} : / {result[1]} - {result[2]} / Count: {Count}";

            static string isNull(T item) => item == null ? "null" : item.ToString();
        }

        private static IEnumerable<T> GetCertainOrder(BinarySearchTree<T> branch, int type)
        {
            if (branch != null)
            {
                var leftBranches = GetCertainOrder(branch.LeftBranch, type);
                var rightBranches = GetCertainOrder(branch.RightBranch, type);
                var thisBranchValue = new T[] { branch.Value };

                if (type == -1)
                {
                    return thisBranchValue.Concat(leftBranches).Concat(rightBranches);
                }
                else if (type == 0)
                {
                    return leftBranches.Concat(thisBranchValue).Concat(rightBranches);
                }
                
                return leftBranches.Concat(rightBranches).Concat(thisBranchValue);
            }

            return new T[0];
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return Transverse().GetEnumerator();
        }

        /// <inheritdoc/>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Transverse().GetEnumerator();
        }
    }
}