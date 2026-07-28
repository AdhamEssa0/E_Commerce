using E_Commerce.Doman.Contracts;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastracture.Repository
{
    public class CachRepository : ICachRepository
    {
        private readonly IDatabase _database;

        public CachRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<string?> GetAsync(string cachKey, CancellationToken ct = default)
        {
            var value = await _database.StringGetAsync(cachKey);
            return value.IsNullOrEmpty ? null : value.ToString();
        }

        public Task SetAsync(string cachKey, string cachValue, TimeSpan? timeToLive = null, CancellationToken ct = default)
        {
            return _database.StringSetAsync(cachKey , cachValue , timeToLive ?? TimeSpan.FromDays(2));
        }
    }
}
