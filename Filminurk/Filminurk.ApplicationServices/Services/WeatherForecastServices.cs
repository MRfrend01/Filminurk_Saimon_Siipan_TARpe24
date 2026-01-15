using Filminurk.Core.Dto.AccuWeatherDTO;
using Filminurk.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Filminurk.ApplicationServices.Services
{
    internal class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDTO> AccuWeatherResult(AccuLocationWeatherResultDTO dto)
        {
            //string apikey = Filminurk.Data.Environment.accuweatherKey;
            //var baseurl = "https://dataservice.accuweather.com/forecasts/v1/daily/1day/";
            //var Cityurl = $"https://dataservice.accuweather.com/locations/v1/cities/search/";

            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(baseurl);
            //    httpClient.DefaultRequestHeaders.Accept.Clear();
            //    httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            //        );
            //    var response = httpClient.GetAsync($"?q={dto.CityName}?apikey={apikey}&details=true").GetAwaiter().GetResult();
            //    var jsonResponse = await response.Content.ReadAsStringAsync();


            //    List<AccuCityCodeRootDTO> weatherData = JsonSerializer.Deserialize<List<AccuCityCodeRootDTO>>(jsonResponse);
            //    dto.CityName = weatherData[0].LocalizedName;
            //    dto.CityCode = weatherData[0].Key;
            //}

            //string waetherResponse = baseurl + $"{dto.CityCode}?apikey={apikey}&details=true";
            //using (var clientWeather = new HttpClient())
            //{
            //    var httpResponseWeather = clientWeather.GetAsync(waetherResponse).GetAwaiter().GetResult();
            //    var jsonResponseWeather = await httpResponseWeather.Content.ReadAsStringAsync();

            //    AccuLocationRootDTO weatherRootDTO = JsonSerializer.Deserialize<AccuLocationRootDTO>(jsonResponseWeather);
            //}
            return null;
        }
    }
}

