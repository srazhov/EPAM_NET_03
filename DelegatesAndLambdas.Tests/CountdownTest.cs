// <copyright file="CountdownTest.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace DelegatesAndLambdas.Tests
{
    using NUnit.Framework;

    /// <summary>Test of the <see cref="Countdown"/> class</summary>
    public class CountdownTest
    {
        /// <summary>Test of the <see cref="Countdown.WhenCountdownEnds"/> event</summary>
        [Test]
        public void Countdown_TestOutputsStringInConsole()
        {
            Countdown countdown = new Countdown();
            countdown.WhenCountdownEnds += () => System.Console.WriteLine("Test finished successfuly");
            countdown.Wait(10);

            Assert.Pass();
        }
    }
}