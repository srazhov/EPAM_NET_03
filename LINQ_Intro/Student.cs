// <copyright file="Student.cs" company="EPAM">
// Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Srazhov Miras</author>
//-----------------------------------------------------------------------

namespace LINQ_Intro
{   
    using System;
    
    /// <summary>Student class</summary>
    public class Student : IComparable<Student>
    {
        /// <summary>Initializes a new instance of the <see cref="Student"/> class</summary>
        /// <param name="name">Name of the student</param>
        /// <param name="testTitle">Name of the test</param>
        /// <param name="testDate">Date of the test </param>
        /// <param name="assessment">Assessment of the test</param>
        public Student(string name, string testTitle, int testDate, int assessment)
        {
            this.Name = name;
            this.TestTitle = testTitle;
            this.TestDate = testDate;
            this.Assessment = assessment;
        }

        /// <summary>Gets the name of the student</summary>
        public string Name { get; }

        /// <summary>Gets the title of the test</summary>
        public string TestTitle { get; }

        /// <summary>Gets a test date</summary>
        public int TestDate { get; }

        /// <summary>Gets an assessment of the test</summary>
        public int Assessment { get; }

        /// <inheritdoc/>
        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.Name.CompareTo(other.Name);
        }
    }
}
