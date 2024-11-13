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
        return await template.QueryAsync("select * from holiday", MapRowToHoliday, cancellationToken);
    }

    public async Task<bool> UpdateAsync(Holiday holiday, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "update holiday set name = @name, start_date = @start, end_date = @end, type_id = @type where id = @id",
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
            "insert into holiday (name, start_date, end_date, type_id) values (@name, @start, @end, @type)",
            cancellationToken,
            new QueryParameter("@name", holiday.Name),
            new QueryParameter("@start", holiday.Start),
            new QueryParameter("@end", holiday.End),
            new QueryParameter("@type", holiday.TypeId));
    }

    public async Task<bool> DeleteAsync(Holiday holiday, CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(
            "delete from holiday where id = @id",
            cancellationToken,
            new QueryParameter("@id", holiday.Id));
    }

    private Holiday MapRowToHoliday(IDataRecord row) =>
            new Holiday(
                    (int)row["id"],
                    (string)row["name"],
                    (DateTime)row["start_date"],
                    (DateTime)row["end_date"],
                    (int)row["type_id"]
            );

    // TODO: Change date variables!!!!
    public async Task<bool> CreateTeableAsync(CancellationToken cancellationToken = default)
    {
        return 1 == await template.ExecuteAsync(@"CREATE TABLE holiday (
                                                    id SERIAL PRIMARY KEY,
                                                    name VARCHAR(30) NOT NULL,
                                                    start_date DATE NOT NULL,
                                                    end_date DATE NOT NULL,
                                                    type_id INT NOT NULL
                                                )", cancellationToken);
    }
}
