using System;
using System.Collections.Generic;
using System.Linq;
using LCP.Subjects;
using LCP.Trainees;

namespace LCP.Courses
{
    public class Course
    {
        private const double MaximumFactor = 10;

        private readonly IList<Trainee> registeredTrainees;
        private readonly IList<Subject> subjects;

        public Course()
        {
            registeredTrainees = new List<Trainee>();
        }

        public Course(IEnumerable<Subject> subjects) : this()
        {
            this.subjects = subjects?.ToList()
                            ?? throw new ArgumentNullException(nameof(subjects));
        }

        public void Enroll(Trainee trainee)
        {
            if (trainee is Pilot pilotTrainee)
            {
                var pilotScore = pilotTrainee.Score;
                pilotScore.Factor = (Math.Min(pilotScore.Factor, MaximumFactor));
            }

            registeredTrainees.Add(trainee);
        }

        public double GetGrade()
        {
            double grade = 0;

            foreach (var subject in subjects)
            {
                if (subject is BinarySubject binarySubject)
                {
                    grade += binarySubject.IsPassed
                        ? 100
                        : 0;
                }
                else
                {
                    grade += subject.Grade;
                }
            }

            return grade;
        }
}
}