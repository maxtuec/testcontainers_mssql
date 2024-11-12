using Microsoft.Extensions.Configuration;
using NextStop.Dal.Ado;
using NextStop.Dal.Common;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionFactory = DefaultConnectionFactory.FromConfiguration(configuration, "NextStopDbConnection");

CancellationTokenSource tokenSource = new CancellationTokenSource();

await TestHolidayAsync(new AdoHolidayDao(connectionFactory), tokenSource.Token);

async Task TestHolidayAsync(AdoHolidayDao adoHolidayDao, CancellationToken token = default)
{
    IEnumerable<Holiday> allHolidays = await adoHolidayDao.GetAllAsync();
    foreach(Holiday holiday in allHolidays)
    {
        Console.WriteLine(holiday.Name);
    }
}