namespace Core.Application.Pipelines.Caching;

public interface ICacheableRequest
{
    string CacheKey { get; }
    bool BypassCache { get; }
    TimeSpan? SlidingExpiration { get; }
}