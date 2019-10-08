using System;
using System.Threading.Tasks;
using DrakeLambert.RefitTutorial.Gateway.ApiServices.JokeApi;
using Microsoft.Extensions.Caching.Memory;

namespace DrakeLambert.RefitTutorial.Gateway.Services
{
    public class DailyClientJokeService : IClientJokeService
    {
        private readonly IJokeApi _jokeApi;
        private readonly IMemoryCache _cache;

        public DailyClientJokeService(IJokeApi jokeApi, IMemoryCache cache)
        {
            _jokeApi = jokeApi;
            _cache = cache;
        }

        public Task<string> GetJokeForClientAsync(string companyName)
        {
            var cacheKey = typeof(DailyClientInfoService).FullName + companyName;
            var now = DateTimeOffset.Now;
            return _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.SetAbsoluteExpiration(new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, 0, now.Offset).AddDays(1));
                var jokeResponse = await _jokeApi.GetRandomJokeAsync();
                return jokeResponse.Joke ?? $"{jokeResponse.Setup}\n{jokeResponse.Delivery}";
            });
        }
    }
}
