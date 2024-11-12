using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MsSql;
using Xunit;

namespace NextStop.Tests;

public class HolidayTest
{
    private readonly MsSqlContainer _mssql = new MsSqlBuilder()
        .WithImage("mcr.microsoft.com/mssql/server:2022-CU10-ubuntu-22.04") //mcr.microsoft.com/mssql/server:2022-latest
        .Build();

    public Task InitializeAsync()
    {
        return _mssql.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _mssql.DisposeAsync().AsTask();
    }

    [Fact]
    public void GetAllHolidays()
    {
        Assert.Equal(2, 2);
    }
}
