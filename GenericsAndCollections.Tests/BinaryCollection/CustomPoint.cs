// <copyright file="CustomPoint.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace GenericsAndCollections.Tests.BinaryCollection
{
    /// <summary>Custom point class that is being used to test</summary>
    internal struct CustomPoint
    {
        /// <summary>Initializes a new instance of the <see cref="CustomPoint"/> struct</summary>
        /// <param name="x">X point</param>
        /// <param name="y">Y point</param>
        public CustomPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>Gets theX coordinate</summary>
        public int X { get; }

        /// <summary>Gets the Y coordinate</summary>
        public int Y { get; }
    }
}
