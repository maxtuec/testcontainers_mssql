using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Common;

public class Stop(string? id, string? name, double? longitude, double? latitude)
{
    public string? Id { get; set;  } = id;
    public string? Name { get; set; } = name;
    public double? Longitude { get; set; } = longitude;
    public double? Latitude { get; set; } = latitude;
}