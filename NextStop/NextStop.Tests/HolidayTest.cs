using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Testcontainers.PostgreSql;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using NextStop.Dal.Common;
using NextStop.Dal.Ado;

namespace NextStop.Tests;

public class HolidayTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
            .WithImage("postgres:15-alpine")
            .WithDatabase("testdb")
            .WithUsername("testuser")
            .WithPassword("testpassword")
            .Build();
    
    private IConnectionFactory? _defaultConnectionFactory;
    private AdoHolidayDao? _adoHolidayDao;

    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
        
        _defaultConnectionFactory = new DefaultConnectionFactory(_postgres.GetConnectionString(), "Npgsql");

        _adoHolidayDao = new AdoHolidayDao(_defaultConnectionFactory);

        CancellationTokenSource cts = new CancellationTokenSource();
        await _adoHolidayDao.CreateTeableAsync(cts.Token);
    }

    public async Task DisposeAsync()
    {
        // Dispose of PostgreSQL container
        await _postgres.DisposeAsync();
    }

    [Fact]
    public async Task GetAllHolidays_ShouldReturnZero_WhenNoHolidaysExist()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        IEnumerable<Holiday>? allHolidays = null;

        if (_adoHolidayDao is not null)
        {
            allHolidays = await _adoHolidayDao.GetAllAsync(cts.Token);
        }
        
        Assert.NotNull(allHolidays);
        Assert.Empty(allHolidays);
    }

    [Fact]
    public async Task InsertHoliday()
    {
        Holiday holiday = new Holiday(null, "Custom Holiday", DateTime.Now, DateTime.Now.Add(TimeSpan.FromDays(2)),1);


    }
}

/*
public class HolidayTest : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:15-alpine")
        .WithDatabase("testdb")         // Set the database name
        .WithUsername("testuser")       // Set the username
        .WithPassword("testpassword")   // Set the password
        .Build();

    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();

        IConnectionFactory defaultConnectionFactory = new DefaultConnectionFactory(_postgres.GetConnectionString(), "Npgsql");
        AdoHolidayDao adoHolidayDao = new AdoHolidayDao(defaultConnectionFactory);
        await adoHolidayDao.CreateTeableAsync(new CancellationTokenSource().Token);
    }

    public async Task DisposeAsync()
    {
        await _postgres.DisposeAsync().AsTask();
    }

    [Fact]
    public async Task GetAllHolidays()
    {
        IConnectionFactory defaultConnectionFactory = new DefaultConnectionFactory(_postgres.GetConnectionString(), "Npgsql");
        AdoHolidayDao adoHolidayDao = new AdoHolidayDao(defaultConnectionFactory);
        IEnumerable<Holiday> allHolidays = await adoHolidayDao.GetAllAsync(new CancellationTokenSource().Token);
        int count = allHolidays.Count();
        Assert.Equal(0, count);
    }
 
}
*/
/*
[Fact]
public async Task InsertHoliday()
{

}
*/