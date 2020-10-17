//-----------------------------------------------------------------------
// <copyright file="Fundamentals.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace FrameworkFundamentals
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class that holds realizations of tasks from Framework Fundamentals' 
    /// </summary>
    public static class Fundamentals
    {
        /// <summary>
        /// Corrects the title considering the exception
        /// </summary>
        /// <param name="title">Correcting title</param>
        /// <param name="exceptions">Exception words</param>
        /// <returns>Corrected title</returns>
        public static string MakeProperTitle(string title, string exceptions = "")
        {
            string[] titleArr = title.Split(' ');
            string[] excArr = exceptions.Split(' ');

            for (int i = 0; i < titleArr.Length; i++)
            {
                string mask = titleArr[i][0] + titleArr[i].Substring(1).ToLower();
                if (!excArr.Any(c => c == mask) || i == 0)
                {
                    titleArr[i] = char.ToUpper(titleArr[i][0]) + titleArr[i].Substring(1).ToLower();
                }
                else
                {
                    titleArr[i] = titleArr[i].ToLower();
                }
            }

            return string.Join(' ', titleArr);
        }

        /// <summary>
        /// Adds or changes the parameter of given URL
        /// </summary>
        /// <param name="url">URL to change</param>
        /// <param name="keyValueParameter">Key to add or change</param>
        /// <returns>Modified URL with extra keys</returns>
        /// <exception cref="System.ArgumentException">URL is not supported</exception>
        public static string AddOrChangeUrlParameter(string url, string keyValueParameter)
        {
            Regex urlRegex = new Regex(@"(http | http(s) ?://)?([\w-]+\.)+[\w-]+[.(\w)]+(\[\?%&=]*)?");
            Regex keyRegex = new Regex(@"\w=\w");

            if (!urlRegex.IsMatch(url) || !keyRegex.IsMatch(keyValueParameter))
            {
                throw new System.ArgumentException();
            }

            List<string> urlSplit = new List<string>(url.Split('?', '&').Where(c => !string.IsNullOrWhiteSpace(c)));
            string[] keysSplit = keyValueParameter.Split('=');

            if (urlSplit.Count == 1)
            {
                return urlSplit[0] + '?' + keyValueParameter;
            }

            int index = urlSplit.FindIndex((c) => c.Contains(keysSplit[0]));
            if (index != -1)
            {
                urlSplit[index] = keyValueParameter;
            }
            else
            {
                urlSplit.Add(keyValueParameter);
            }

            string result = string.Join('&', urlSplit).Remove(0, urlSplit[0].Length + 1);
            return urlSplit[0] + '?' + result;
        }

        /// <summary>Removes the same sequences in a row</summary>
        /// <param name="enumerable">Enumerable object</param>
        /// <returns>Unique sequence</returns>
        public static IEnumerable UniqueInOrder(IEnumerable enumerable)
        {
            IEnumerator enumerator = enumerable.GetEnumerator();
            List<object> results = new List<object>();
            object repeat = null;

            while (enumerator.MoveNext())
            {
                if (!enumerator.Current.Equals(repeat))
                {
                    repeat = enumerator.Current;
                    results.Add(enumerator.Current);
                    yield return enumerator.Current;
                }
            }
        }

        /// <summary>Reverses given text with ' ' separator</summary>
        /// <param name="text">This text</param>
        /// <returns>Reversed text</returns>
        public static string ReverseWords(string text)
        {
            StringBuilder result = new StringBuilder(text.Length);

            var edit = text.Split(' ');
            for (int i = edit.Length - 1; i >= 1; i--)
            {
                result.Append(edit[i] + " ");
            }

            result.Append(edit[0]);
            return result.ToString();
        }

        /// <summary>Parses given strings to long type and calculates the result</summary>
        /// <param name="first">First argument</param>
        /// <param name="second">Second argument</param>
        /// <returns>Merged long in string type</returns>
        public static string GetSumOfTwoNumbers(string first, string second)
        {
            if (long.TryParse(first, out long resultFirst) && long.TryParse(second, out long resultSecond))
            {
                return (resultFirst + resultSecond).ToString();
            }

            return null;
        }
    }
}