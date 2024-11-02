using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class StopLog(int? id, DateTime? time, int? routeStopId, int? tripId)
{
    public int? Id { get; set; } = id;
    public DateTime? Time { get; set; } = time;
    public int? RouteStopId { get; set; } = routeStopId;
    public int? TripId { get; set; } = tripId;
}
