using System;
using Newtonsoft.Json;

namespace WeatherForcast
{
	public class WeatherForcastController: IWeatherForcastControllerInterface
    {
		//
		private readonly IWeatherForecastRepoInterface _repo;

		//
		public WeatherForcastController(IWeatherForecastRepoInterface repo)
		{
			this._repo = repo;
		}

		//
		public async Task<ForcastPeriodDto[]> GetWeeklyForcast(double longitude, double latitude)
		{
			//	get forcast from repo
			WeatherForcastResponseObject response = await this._repo.GetWeatherForcast(longitude, latitude);

			//	nothing in ther forecast cluster
			if (response.properties.periods.Length == 0) throw new UnableToRetrieveWeatherForcast();

            //	translate the response into a dto
            return response.properties.periods.Select(period => period.AsDto()).ToArray();
		}
	}
}

