using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using LCP.Scores;
using LCP.Subjects;
using LCP.Trainees;

namespace LCP.Courses
{
    public class Course
    {
        private static readonly double MaximumFactor = 10;

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
            if (trainee is Pilot pilotTrainee) {
                var pilotScore = pilotTrainee.Score;
                pilotScore.Factor = (Math.Min(pilotScore.Factor, MaximumFactor));
            }

            registeredTrainees.Add(trainee);
        }

        public double GetScore()
        {
            double totalScore = 0;

            foreach (var trainee in registeredTrainees)
            {
                var score = trainee.Score;
                if (score is PilotScore pilotScore) {
                    totalScore += score.Value * pilotScore.Factor;
                } else
                {
                    totalScore += score.Value;
                }
            }

            return totalScore;
        }

        public double GetGrade()
        {
            double grade = 0;

            foreach (var subject in subjects)
            {
                if (subject is BinarySubject binarySubject) {
                    grade += binarySubject.IsPassed 
                        ? 100 
                        : 0;
                } else
                {
                    grade += subject.Grade;
                }
            }

            return grade;
        }
}
}