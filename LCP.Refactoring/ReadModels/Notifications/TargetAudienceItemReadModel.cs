using System;

namespace LCP.Refactoring.ReadModels.Notifications
{
    public class TargetAudienceItemReadModel <T> where T: struct, IConvertible
    {
        public T Value { get; set; }
        public bool IsChecked { get; set; }
    }
}