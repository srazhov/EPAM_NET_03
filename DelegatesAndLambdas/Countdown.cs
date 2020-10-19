// <copyright file="Countdown.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace DelegatesAndLambdas
{
    using System.Threading;
    
    /// <summary>Simple countdown class</summary>
    public class Countdown
    {
        /// <summary>Event handler</summary>
        public delegate void EventHandler();

        /// <summary>An event that executes when countdown ends</summary>
        public event EventHandler WhenCountdownEnds;

        /// <summary>Starts a countdown</summary>
        /// <param name="milliseconds">Milliseconds to wait</param>
        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);

            this.WhenCountdownEnds?.Invoke();
        }
    }
}