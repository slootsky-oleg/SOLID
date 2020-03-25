using System.Collections.Generic;
using System.Linq;
using LCP.Refactoring.Courses;
using LCP.Refactoring.Courses.Driving;
using LCP.Refactoring.Courses.Driving.Extreme;
using LCP.Refactoring.Courses.Shooting;

namespace LCP.Refactoring
{
    public class Syllabus
    {
        private readonly IList<ExtremeDrivingCourse> extremeDrivingCourses;
        private readonly IList<DrivingCourse> drivingCourses;
        private readonly IList<ShootingCourse> shootingCourses;

        public IReadOnlyList<ExtremeDrivingCourse> ExtremeDrivingCourses => extremeDrivingCourses.ToList();
        public IReadOnlyList<DrivingCourse> DrivingCourses => drivingCourses.ToList();
        public IReadOnlyList<ShootingCourse> ShootingCourses => shootingCourses.ToList();

        public void Enroll(ExtremeDrivingTrainee trainee, WIll wIll)
        {
            foreach (var course in ExtremeDrivingCourses)
            {
                course.Enroll(trainee, wIll);
            }
        }
        
        public void Enroll(DrivingTrainee trainee)
        {
            foreach (var course in DrivingCourses)
            {
                course.Enroll(trainee);
            }
        }

        public void Enroll(ShootingTrainee trainee)
        {
            foreach (var course in ShootingCourses)
            {
                course.Enroll(trainee);
            }
        }
    }
}