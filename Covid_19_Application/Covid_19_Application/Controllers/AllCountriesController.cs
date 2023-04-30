using Covid_19_Application.Models.DTOs;
using Covid_19_Application.Models.Interfaces;
using Covid_19_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Xceed.Wpf.Toolkit;

namespace Covid_19_Application.Controllers
{
    public class AllCountriesController : Controller
    {
        private readonly IMyRecord _myRecord;
        string baseURL = "https://api.covid19api.com/";

        public AllCountriesController(IMyRecord myRecord)
        {
            _myRecord = myRecord;
           
        }



        // GET: AllCountriesController
        public async Task<ActionResult> Index()
        {
            var WholeSummary = new WholeSummary();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("summary");

                string results = getData.Content.ReadAsStringAsync().Result;
                WholeSummary = JsonConvert.DeserializeObject<WholeSummary>(results);
                List<CountryForSmry> countries = WholeSummary.Countries;
                var CountryForSmryDTO = from c in countries
                                        select new MyRecord()
                                        {
                                            ID = c.ID,
                                            Country = c.Country,
                                            TotalConfirmed = c.TotalConfirmed,
                                            Date = c.Date,
                                            TotalDeaths = c.TotalDeaths,
                                            TotalRecovered = c.TotalRecovered
                                        };
                ViewData.Model = CountryForSmryDTO;
            }
         



            return View();
        }



     
        public async Task<ActionResult> Get(string id)
        {
            await _myRecord.Get(id);
            return View();
        }

        public async Task<ActionResult> GetAll()
        {
            List<MyRecord> records = await _myRecord.GetAll();
            if(records.Count >= 1)
            {
                return View(records);

            }
            else
            {
                return View("Empty");
            }
        }

       
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public  async Task<ActionResult> Create(MyRecord myRecord)
        {
            MyRecord record = await _myRecord.Get(myRecord.ID);
            if(record == null)
            {
               await _myRecord.Create(myRecord);
               return RedirectToAction("Index");

            }
            else
            {
                return View("AlreadyExisted");
            }
           
        }

 
        public async Task<ActionResult> Delete(string id)
        {
            await _myRecord.Delete(id);
            return RedirectToAction("GetAll");
        }

       
    }
}
