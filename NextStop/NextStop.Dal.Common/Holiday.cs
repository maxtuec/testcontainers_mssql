using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class Holiday(int? id, string? name, DateTime? start, DateTime? end, int? typeId)
{
    public int? Id { get; set; } = id;
    public string? Name { get; set; } = name;
    public DateTime? Start { get; set; } = start;
    public DateTime? End { get; set; } = end;
    public int? TypeId { get; set; } = typeId;
}
