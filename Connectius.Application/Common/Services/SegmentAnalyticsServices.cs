using Connectius.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Segment.Analytics;
using Segment.Analytics.Compat;

namespace Connectius.Application.Services;

public class SegmentAnalyticsServices : IAnalyticsService
{
    private readonly Analytics _segmentClient;
    private readonly ILogger<SegmentAnalyticsServices> _logger;

    public SegmentAnalyticsServices(Analytics segmentClient, ILogger<SegmentAnalyticsServices> logger)
    {
        _segmentClient = segmentClient;
        _logger = logger;
    }
    
    public async Task TrackUserCreated(Guid id, string username)
    {
        try
        {
            _segmentClient.Identify(id.ToString(), new Traits
            {
                {"username", username},
                {"createdAt", DateTime.Now}
            });
            
            _segmentClient.Track(id.ToString(), "Usuário criado!", new Properties
            {
                {"username", username}
            });

            await Task.Run(() => _segmentClient.Flush());
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Erro ao rastrear a criação do usuário para {UserId}", id);
        }
    }

    public Task TrackUserLogin(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task TrackUserAction(Guid id, string action, Dictionary<string, object> parameters)
    {
        throw new NotImplementedException();
    }
}