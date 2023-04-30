using Covid_19_Application.Models;
using Covid_19_Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        string baseURL = "https://api.covid19api.com/";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string Country, string FromDate, string ToDate)
        {
            CountryAndTotal countryAndTotal = new CountryAndTotal();


            var worldTotal = new WorldTotal();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getDataTotal = await client.GetAsync("world/total");

              
               
                string results = getDataTotal.Content.ReadAsStringAsync().Result;
                worldTotal = JsonConvert.DeserializeObject<WorldTotal>(results);
               
                countryAndTotal.worldTotal = worldTotal;

            }



            var countryData = new List<SpecificCountry>();



            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("/country/" + Country + "/status/confirmed?from=" + FromDate + "&to=" + ToDate);


                string results = getData.Content.ReadAsStringAsync().Result;
                
                countryData = JsonConvert.DeserializeObject<List<SpecificCountry>>(results);
                var countryDto = from c in countryData
                                 select new SpecificCountryDTO()
                                 {
                                     Cases = c.Cases,
                                     Date = c.Date
                                 };
                if (Country == null && FromDate == null && ToDate == null)
                {
                    countryAndTotal.countryDto = countryDto.Take(0);

                }
                else
                {
                 countryAndTotal.countryDto = countryDto;

                }

            }

            return View(countryAndTotal);
        }

 

    }
}
