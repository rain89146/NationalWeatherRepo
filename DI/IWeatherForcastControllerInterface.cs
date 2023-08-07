using System;
namespace WeatherForcast
{
	public interface IWeatherForcastControllerInterface
	{
        Task<ForcastPeriodDto[]> GetWeeklyForcast(double longitude, double latitude);
    }
}

