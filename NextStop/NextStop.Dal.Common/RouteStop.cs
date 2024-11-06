using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class RouteStop(int? routeId, int? stopId, int? timePassed)
{
    public int? RouteId { get; set; } = routeId;
    public int? StopId { get; set; } = stopId;
    public int? TimePassed { get; set; } = timePassed;
}
