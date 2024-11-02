using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class PlannedRoute(int? id, TimeSpan? startTime, int? typeOfDay, int? routeId)
{
    public int? Id { get; set; } = id;
    public TimeSpan? StartTime { get; set; } = startTime;
    public int? TypeOfDay { get; set; } = typeOfDay;
    public int? RouteId { get; set; } = routeId;
}
