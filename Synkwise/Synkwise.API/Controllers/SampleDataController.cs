using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Synkwise.BLL.Ports;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Synkwise.API.Controllers
{
    [Produces("application/json")]
	[Route("api/SampleData")]
    public class SampleDataController : Controller
    {
		private static string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

        private readonly IUserService _accountService;

        public SampleDataController(IUserService accountService)
        {
            _accountService = accountService;
        }

        [EnableCors("AllowAllHeaders")]
		[HttpGet("WeatherForecasts")]
		public IEnumerable<WeatherForecast> WeatherForecasts()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			});
		}

		public class WeatherForecast
		{
			public string DateFormatted { get; set; }
			public int TemperatureC { get; set; }
			public string Summary { get; set; }

			public int TemperatureF
			{
				get
				{
					return 32 + (int)(TemperatureC / 0.5556);
				}
			}
		}
    }
}
