using System;
namespace WeatherForcast
{
    public class UnitCodeValueObject
    {
        public string? unitCode { get; set; }
        public double? value { get; set; }
    }

    public class ForcastPeriod
    {
        public int number { get; set; }
        public string? name { get; set; }
        public string? startTime { get; set; }
        public string? endTime { get; set; }
        public bool isDaytime { get; set; }
        public double temperature { get; set; }
        public string? temperatureUnit { get; set; }
        public string? temperatureTrend { get; set; }
        public WeatherUnitCodeValueObject? probabilityOfPrecipitation { get; set; }
        public WeatherUnitCodeValueObject? dewpoint { get; set; }
        public WeatherUnitCodeValueObject? relativeHumidity { get; set; }
        public string? windSpeed { get; set; }
        public string? windDirection { get; set; }
        public string? icon { get; set; }
        public string? shortForecast { get; set; }
        public string? detailedForecast { get; set; }
    }

    public class ForcastPropertiesElevation
    {
        public string unitCode { get; set; }
        public double value { get; set; }
    }

    public class ForcastResponseProperties
    {
        public string updated { get; set; }
        public string units { get; set; }
        public string forecastGenerator { get; set; }
        public string generatedAt { get; set; }
        public string updateTime { get; set; }
        public string validTimes { get; set; }
        public WeatherUnitCodeValueObject? elevation { get; set; }
        public ForcastPeriod[] periods { get; set; }
    }

	public class WeatherForcastResponseObject
	{
		public string? type { get; set; }
        public ForcastResponseProperties properties { get; set; }
    }
}

