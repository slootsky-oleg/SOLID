using System.Collections.Generic;
using LCP.Courses;
using LCP.Subjects;
using LCP.Trainees;

namespace LCP
{
    public class Demo
    {
        public void Run()
        {
            var subjects = new List<Subject>
            {
                new Subject("INTRODUCTORY FLIGHT"),
                new BinarySubject("EMERGENCY PROCEDURES"),
                new BinarySubject("TRAFFIC PATTERN REVIEW"),
                new Subject("SOLO PRACTICAL TEST PREPARATION")
            };

            var course = new Course(subjects);

            course.Enroll(new Trainee("Jon Snow"));
            course.Enroll(new Trainee("Tom Hanks"));
            course.Enroll(new Pilot("Mordechai Hod"));
            course.Enroll(new Trainee("Will Smith"));


            var subjectGrade = course.GetGrade();
            var traineeGrade = course.GetScore();
        }
    }
}