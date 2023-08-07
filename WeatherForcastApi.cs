using System.Net.Http.Headers;

namespace WeatherForcast;
public class WeatherForcastApi
{
    //
    private readonly WeatherForcastController _controller;

    //
    private static readonly HttpClient _HttpClient = new();

    //
    public WeatherForcastApi()
    {
        //
        string _ContentType = "application/json";
        string _UserAgent = "HttpClient";

        //  reset headers
        _HttpClient.DefaultRequestHeaders.Accept.Clear();
        _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
        _HttpClient.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

        //  assign controller
        this._controller = new WeatherForcastController( new WeatherForcastRepo(_HttpClient) );
    }

    /// <summary>
    /// Get weekly weather forcast
    /// </summary>
    /// <param name="longtitude"></param>
    /// <param name="latitude"></param>
    /// <returns></returns>
    public async Task<ForcastPeriodDto[]> GetWeeklyForcast(double longtitude, double latitude)
    {
        return await this._controller.GetWeeklyForcast(longtitude, latitude);
    }
}

