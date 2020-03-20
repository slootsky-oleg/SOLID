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
                new Subject(),
                new BinarySubject(),
                new BinarySubject(),
                new Subject()
            };

            var course = new Course(subjects);

            course.Enroll(new Trainee());
            course.Enroll(new Trainee());
            course.Enroll(new Pilot());
            course.Enroll(new Trainee());


            var subjectGrade = course.GetGrade();
            var traineeGrade = course.GetScore();
        }
    }
}