using System;
using Newtonsoft.Json;
using HelperBox;

namespace WeatherForcast
{
	public class WeatherForcastRepo: IWeatherForecastRepoInterface
    {
		//
		private readonly HttpClient _hpClient;

		//
		public WeatherForcastRepo(HttpClient httpClient)
		{
			this._hpClient = httpClient;
		}

		//	Get weather forecast catalog based on lat and long
		private async Task<WeatherApiCatalog> GetWeatherForcastCatalog(double longitude, double latitude)
		{
			//
			string requestUrl = $"https://api.weather.gov/points/{longitude},{latitude}";

			//	1.	load catalog info
			using HttpResponseMessage response = await this._hpClient.GetAsync(requestUrl).ConfigureAwait(false);

			//	1.1	unable to get request response
			if (response is null) throw new HttpRequestException();

			//	1.2	find out what's wrong
			if (!response.IsSuccessStatusCode)
			{
				//	if it's because of not found
				if ((int)response.StatusCode == 404) throw new UnableToFindLocationException(longitude, latitude, response.ReasonPhrase);

				//	everything else
				throw new HttpRequestFailedException(response.ReasonPhrase, (int)response.StatusCode);
            }

			//
			response.EnsureSuccessStatusCode();

			//
			string responseContent = await response.Content.ReadAsStringAsync();

            //
            if (string.IsNullOrWhiteSpace(responseContent)) throw new UnableToRetrieveWeatherCatalog();

            //	2.	parse it into catalog object
            return HelperTools.StringToObject<WeatherApiCatalog>(responseContent);
        }

		//	Get weather forcast based on lat and long
		public async Task<WeatherForcastResponseObject> GetWeatherForcast(double longitude, double latitude)
		{
            //	1.	get weather forcast catalog
            WeatherApiCatalog forcastCatalog = await this.GetWeatherForcastCatalog(longitude, latitude);

            //	2.	get the weekly forcast api url
            string weatherForecastEndpoint = forcastCatalog.properties.forecast;

			//	3.	load forecast info
			using HttpResponseMessage response = await this._hpClient.GetAsync(weatherForecastEndpoint).ConfigureAwait(false);

			//
			response.EnsureSuccessStatusCode();

			//
            string responseContent = await response.Content.ReadAsStringAsync();

			//
			if (string.IsNullOrWhiteSpace(responseContent)) throw new UnableToRetrieveWeatherForcast();

            //	4.	parse it into response object
            return HelperTools.StringToObject<WeatherForcastResponseObject>(responseContent);

        }
	}
}