using System;
using LCP.Refactoring.Application.Notifications.Course;
using LCP.Refactoring.Domain.Notifications;
using LCP.Refactoring.Domain.Services;

namespace LCP.Refactoring.Application
{
    public class TargetAudienceDto <T> where T : struct, IConvertible
    {
        public T Value { get; }
        public bool IsSelected { get; }
        public string ValueText { get; }

        public TargetAudienceDto(TargetAudience<T> source, string valueText)
        {
            Value = source.Value;
            IsSelected = source.IsChecked;
            ValueText = valueText;
        }
    }
}