using System;

namespace WeatherForcast
{
	public static class Extension
	{
        /// <summary>
        /// Convert ForcastPeriod into ForcastPeriodDto
        /// </summary>
        /// <param name="forcast"></param>
        /// <returns></returns>
        public static ForcastPeriodDto AsDto(this ForcastPeriod forcast)
		{
			//	calculate F into C
			double celsius = (forcast.temperature - 32) * 5 / 9;

            //  mapping
            TemperatureObject tempObject = new TemperatureObject() {
				temperatureInC = Math.Round(celsius,2),
				temperatureInF = forcast.temperature
			};

            //  mapping
            ForcastPeriodDto dto = new ForcastPeriodDto
            {
                name = forcast.name,
                isDaytime = forcast.isDaytime,
                detailedForecast = forcast.detailedForecast,
                shortForecast = forcast.shortForecast,
                windSpeed = forcast.windSpeed,
                windDirection = forcast.windDirection,
                relativeHumidity = forcast.relativeHumidity,
                temperatureObj = tempObject
            };

            //
            return dto;
		}
	}
}

