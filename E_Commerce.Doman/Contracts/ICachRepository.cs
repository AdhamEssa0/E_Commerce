using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Doman.Contracts
{
    public interface ICachRepository
    {
        Task<string?> GetAsync(string cachKey , CancellationToken ct = default);
        Task SetAsync(string cachKey , string cachValue , TimeSpan? timeToLive = default , CancellationToken ct = default);
    }
}
