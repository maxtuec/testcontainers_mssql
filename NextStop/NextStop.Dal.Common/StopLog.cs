using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class StopLog(int? id, DateTime? time, int? routeId, string? stopId, int? tripId)
{
    public int? Id { get; set; } = id;
    public DateTime? Time { get; set; } = time;
    public int? RouteId { get; set; } = routeId;
    public string? StopId { get; set; } = stopId;
    public int? TripId { get; set; } = tripId;
}
