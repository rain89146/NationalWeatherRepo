using System;
namespace WeatherForcast
{
	public interface IWeatherForecastRepoInterface
	{
        Task<WeatherForcastResponseObject> GetWeatherForcast(double longitude, double latitude);
    }
}

