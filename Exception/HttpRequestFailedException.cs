using System;
namespace WeatherForcast
{
	public class HttpRequestFailedException: Exception
	{
		private readonly string reason;
		private readonly int statusCode;

        public HttpRequestFailedException(string reason, int code)
		{
			this.reason = reason;
			this.statusCode = code;
		}

        public override string Message
		{
			get
			{
				return (this.reason is not null) ? $"Http request failed. reason: {this.reason}, code: {this.statusCode}" : "Http request failed";
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