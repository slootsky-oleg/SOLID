using System.Collections.Generic;
using LCP.Courses;

namespace LCP
{
    public class Syllabus
    {
        public IList<ICourse> Courses { get; set; }

        public void Enroll(ITrainee trainee)
        {
            foreach (var course in Courses)
            {
                course.Enroll(trainee);
            }
        }
    }
}