using System;
namespace WeatherForcast
{
	public class UnableToRetrieveWeatherCatalog: Exception
	{
		private readonly string _message;

		public UnableToRetrieveWeatherCatalog()
		{
			this._message = "Unable to retrieve weather catalog";
		}

        public override string Message
		{
			get
			{
				return this._message;
			}
		}

        public override string HelpLink
        {
            get
            {
                return "https://www.google.com";
            }
        }
    }
}

