//-----------------------------------------------------------------------
// <copyright file="MyCustomFormat.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace FrameworkFundamentals
{
    using System;
    using System.Globalization;

    /// <summary>Custom formatter</summary>
    public class MyCustomFormat : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Formats given format to string with special rules
        /// </summary>
        /// <param name="format">This format</param>
        /// <param name="arg">This argument</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>Formatted string</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is decimal @decimal)
            {
                // This is totally wrong, it's using just for example
                if (format == "#,##.00")
                {
                    return @decimal.ToString(format, new CultureInfo("en-US")).Replace(',', '/');
                }
            }

            return arg.ToString();
        }

        /// <summary>
        /// Gets the format
        /// </summary>
        /// <param name="formatType">Format type</param>
        /// <returns>format of this type</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }
    }
}
