using Connectius.Domain.Events;

namespace Connectius.Application.Common.Interfaces;

public interface IAnalyticsService
{
    Task TrackUserCreated(Guid id, string username);
    Task TrackUserLogin(Guid id);
    Task TrackUserAction(Guid id, string action, Dictionary<string, object> parameters);
}