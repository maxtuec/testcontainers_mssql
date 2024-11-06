using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class Trip(int? id, int? delay, int? plannedRouteId)
{
    public int? Id { get; set; } = id;
    public int? Delay { get; set; } = delay;
    public int? PlannedRouteId { get; set; } = plannedRouteId;
}
