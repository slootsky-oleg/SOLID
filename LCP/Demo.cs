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

            course.Complete("INTRODUCTORY FLIGHT", "Jon Snow", 80);
            course.Complete("EMERGENCY PROCEDURES", "Jon Snow", 80);
            course.Complete("TRAFFIC PATTERN REVIEW", "Jon Snow", 80);
            course.Complete("SOLO PRACTICAL TEST PREPARATION", "Jon Snow", 80);


            var subjectGrade = course.GetGrade();
        }
    }
}