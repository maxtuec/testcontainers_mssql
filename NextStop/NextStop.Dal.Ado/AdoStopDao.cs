using NextStop.Dal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextStop.Dal.Ado;

public class AdoStopDao : IStopDao
{
    private readonly AdoTemplate template;

    public AdoStopDao(IConnectionFactory connectionFactory)
    {
        template = new AdoTemplate(connectionFactory);
    }

    public async Task<IEnumerable<Stop>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await template.QueryAsync(
            "select * from dbo.stop",
            MapRowToStop,
            cancellationToken);
    }

    public async Task<bool> InsertAsync(Stop stop, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "insert into dbo.stop (id, name, longitude, latitude) values (@id, @name, @longitude, @latitude)",
            cancellationToken,
            new QueryParameter("@id", stop.Id),
            new QueryParameter("@name", stop.Name),
            new QueryParameter("@longitude", stop.Longitude),
            new QueryParameter("@latitude", stop.Latitude));
    }

    public async Task<bool> UpdateAsync(Stop stop, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "update dbo.stop set name = @name, longitude = @longitude, latitude = @latitude where id = @id",
            cancellationToken,
            new QueryParameter("@id", stop.Id),
            new QueryParameter("@name", stop.Name),
            new QueryParameter("@longitude", stop.Longitude),
            new QueryParameter("@latitude", stop.Latitude));
    }

    private Stop MapRowToStop(IDataRecord row) =>
           new Stop(
                   (string)row["id"],
                   (string)row["name"],
                   (double)row["longitude"],
                   (double)row["latitude"]
           );
}
