using System;
namespace WeatherForcast
{
    public class TemperatureObject
    {
        public double temperatureInF { get; set; }
        public double temperatureInC { get; set; }
    }
	public class ForcastPeriodDto
	{
        public string? name { get; set; }
        public bool isDaytime { get; set; }
        public TemperatureObject? temperatureObj { get; set; }
        public WeatherUnitCodeValueObject? relativeHumidity { get; set; }
        public string? windSpeed { get; set; }
        public string? windDirection { get; set; }
        public string? shortForecast { get; set; }
        public string? detailedForecast { get; set; }
    }
}

