using E_Commerce.Application.Contracts;
using E_Commerce.Doman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Application.Service
{
    public class CacheService : ICacheService
    {
        private readonly ICachRepository _cachRepo;

        public CacheService(ICachRepository cachRepo)
        {
            _cachRepo = cachRepo;
        }
        public async Task<string?> GetDataAsync(string cacheKey, CancellationToken ct = default)
            => await _cachRepo.GetAsync(cacheKey, ct);

        public async Task SetDataAsync(string cacheKey, string cacheValue, TimeSpan? TimeToLive = null, CancellationToken ct = default)
        {
            var jsonValue = JsonSerializer.Serialize(cacheValue);
            await _cachRepo.SetAsync(cacheKey, jsonValue, TimeToLive, ct);
        }
    }
}
