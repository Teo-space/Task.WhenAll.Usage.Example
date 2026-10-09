Magenta("Start");


Guid airBookingId = default;
Guid hotelBookingId = default;

Task<Guid> airBookingTask = Task.Run(async () =>
{
    await Task.Delay(110);

    DarkBlue("AirBookingCommand");

    throw new AirBookingException("AirBookingCommand Failed");

    return Guid.NewGuid();
});

Task<Guid> hotelBookingTask = Task.Run(async () =>
{
    await Task.Delay(120);

    DarkCyan("HotelBookingCommand");

    throw new HotelBookingException("HotelBookingCommand Failed");

    return Guid.NewGuid();
});

Task allTasks = Task.WhenAll(airBookingTask, hotelBookingTask);

try
{
    await allTasks;

    airBookingId = airBookingTask.Result;
    hotelBookingId = hotelBookingTask.Result;
}
catch (Exception ex)
{
    DarkRed("Ошибка");
    DarkRed(ex.Message);

    AggregateException? aggregateException = allTasks.Exception;

    if (aggregateException is not null)
    {
        Red(aggregateException.Message);

        foreach (Exception innerEx in aggregateException.InnerExceptions)
        {
            DarkYellow(innerEx);
        }
    }
}

Magenta("End");

class AirBookingException(string message) : Exception(message);
class HotelBookingException(string message) : Exception(message);