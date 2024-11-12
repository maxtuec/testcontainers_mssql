using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common
{
    public interface IStopDao
    {
        Task<IEnumerable<Stop>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Stop stop, CancellationToken cancellationToken = default);
        Task<bool> InsertAsync(Stop stop, CancellationToken cancellationToken = default);
    }
}
