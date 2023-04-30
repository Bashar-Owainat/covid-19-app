namespace Covid_19_Application.Models
{
    public class CountryForSmry
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public string Slug { get; set; }

        public int NewConfirmed { get; }

        public int TotalConfirmed { get; set; }

        public int NewDeaths { get; set; }

        public int TotalDeaths { get; set; }

        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }

        public string Date { get; set; }

        public Premium Premium { get; set; }
    }

    public class Premium
    {

    }
}



