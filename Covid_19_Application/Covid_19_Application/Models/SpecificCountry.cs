using System;

namespace Covid_19_Application.Models
{
    public class SpecificCountry
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string CityCode { get; set; }
            
        public Double Lat { get; set; }
        public Double Lon { get; set; }

        public int Cases { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

    }
}
