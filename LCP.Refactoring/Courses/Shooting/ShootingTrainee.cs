﻿using LCP.Refactoring.Values;

namespace LCP.Refactoring.Courses.Shooting
{
    public class ShootingTrainee : ITrainee
    {
        public bool HasLicense { get; set; }
        public Age Age { get; set; }
        public bool IsFirearmsSafetyCourseCompleted { get; set; }
    }
}