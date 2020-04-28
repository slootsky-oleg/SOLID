using System;
using LCP.Refactoring.Domain.Entities.Notifications;

namespace LCP.Refactoring.Application.Notifications
{
    public class TargetAudienceDto <T> where T : struct, IConvertible
    {
        public T Value { get; }
        public bool IsSelected { get; }
        public string ValueText { get; }

        public TargetAudienceDto(TargetAudienceItem<T> source, string valueText)
        {
            Value = source.Value;
            IsSelected = source.IsChecked;
            ValueText = valueText;
        }
    }
}