using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class Route(int? id, DateTime? validFrom, DateTime? validUntil)
{
    public int? Id { get; set; } = id;
    public DateTime? ValidFrom { get; set; } = validFrom;
    public DateTime? ValidUntil { get; set; } = validUntil;
}
