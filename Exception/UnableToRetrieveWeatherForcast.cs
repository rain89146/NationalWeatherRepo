using System;
namespace WeatherForcast
{
	public class UnableToRetrieveWeatherForcast: Exception
	{
        public override string Message {
			get
			{
				return "Unable to retrieve weather forcast information";
			}
		}
    }
}

