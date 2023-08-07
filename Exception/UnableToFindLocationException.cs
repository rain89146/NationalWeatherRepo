using System;
namespace WeatherForcast
{
	public class UnableToFindLocationException: Exception
	{
		private readonly double _longitude;
		private readonly double _latitude;
		private readonly string _ogMessage;


        public UnableToFindLocationException(double longitude, double latitude, string ogMessage)
		{
			this._longitude = longitude;
			this._latitude = latitude;
			this._ogMessage = ogMessage;
		}

		public override string Message
		{
			get
			{
				return $"Unable to locate the coordinates of Long: {this._longitude} Lat: {this._latitude}. original message: {this._ogMessage}";
			}
		}
	}
}

