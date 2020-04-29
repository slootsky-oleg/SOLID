using System;

namespace LCP.Refactoring.Application.Notifications
{
    public interface ITargetAudienceTextBuilder<in T> where T : struct, IConvertible
    {
        string Build(T audience);
    }
}