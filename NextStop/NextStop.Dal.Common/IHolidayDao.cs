using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public interface IHolidayDao
{
    Task<IEnumerable<Holiday>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Holiday holiday, CancellationToken cancellationToken = default);
    Task<bool> InsertAsync(Holiday holiday, CancellationToken cancellationToken= default);
    Task<bool> DeleteAsync(Holiday holiday, CancellationToken cancellationToken= default);
    Task<bool> CreateTeableAsync(CancellationToken cancellationToken = default);
}
