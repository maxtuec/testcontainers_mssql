using NextStop.Dal.Common;
using System.Data;
using System;

namespace NextStop.Dal.Ado;

public class AdoHolidayDao : IHolidayDao
{
    private readonly AdoTemplate template;

    public AdoHolidayDao(IConnectionFactory connectionFactory)
    {
        template = new AdoTemplate(connectionFactory);
    }

    public async Task<IEnumerable<Holiday>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await template.QueryAsync("select * from dbo.holiday", MapRowToHoliday, cancellationToken);
    }

    public async Task<bool> UpdateAsync(Holiday holiday, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "update dbo.holiday set name = @name, start = @start, end = @end, type_id = @type where id = @id",
            cancellationToken,
            new QueryParameter("@name", holiday.Name),
            new QueryParameter("@start", holiday.Start),
            new QueryParameter("@end", holiday.End),
            new QueryParameter("@type", holiday.TypeId),
            new QueryParameter("@id", holiday.Id));
    }

    public async Task<bool> InsertAsync(Holiday holiday, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "insert into dbo.holiday (name, start, end, type_id) values (@name, @start, @end, @type)",
            cancellationToken,
            new QueryParameter("@name", holiday.Name),
            new QueryParameter("@start", holiday.Start),
            new QueryParameter("@end", holiday.End),
            new QueryParameter("@type", holiday.TypeId));
    }

    public async Task<bool> DeleteAsync(Holiday holiday, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "delete from dbo.holiday where id = @id",
            cancellationToken,
            new QueryParameter("@id", holiday.Id));
    }

    private Holiday MapRowToHoliday(IDataRecord row) =>
            new Holiday(
                    (int)row["id"],
                    (string)row["name"],
                    (DateTime)row["start"],
                    (DateTime)row["end"],
                    (int)row["type_id"]
            );
}
