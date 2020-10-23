// <copyright file="CustomBook.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Tests.BinaryCollection
{
    using System;
    
    /// <summary>Custom book class</summary>
    public class CustomBook : IComparable<CustomBook>
    {
        /// <summary>Initializes a new instance of the <see cref="CustomBook"/> class</summary>
        /// <param name="title">Title of this book</param>
        /// <param name="pages">Count of the pages</param>
        public CustomBook(string title, int pages)
        {
            this.Titile = title;
            this.Pages = pages;
        }

        /// <summary>Gets the title of this book</summary>
        public string Titile { get; }

        /// <summary>Gets the count of the pages of this book</summary>
        public int Pages { get; }

        /// <summary>Compares two <see cref="CustomBook"/> instances</summary>
        /// <param name="other">Other object</param>
        /// <returns>-1 if other is less than this. 0 if they are equal. 1 if this instance is bigger</returns>
        public int CompareTo(CustomBook other)
        {
            if (other == null)
            {
                return -1;
            }

            if (this.Pages.CompareTo(other.Pages) == 0)
            {
                return this.Titile.CompareTo(other.Titile);
            }

            return this.Pages.CompareTo(other.Pages);
        }

        /// <summary>To String</summary>
        /// <returns>To string</returns>
        public override string ToString()
        {
            return $"{Titile} {Pages}";
        }

        /// <summary>Checks if two objects are equal</summary>
        /// <param name="obj">Checking object</param>
        /// <returns>True if equal</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is CustomBook))
            {
                return false;
            }

            var a = obj as CustomBook;
            return this.Titile == a.Titile && this.Pages == a.Pages;
        }

        /// <summary>Gets the hash code</summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return this.Titile.GetHashCode() * this.Pages.GetHashCode();
        }
    }
}
