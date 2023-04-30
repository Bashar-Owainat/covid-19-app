using System.Collections.Generic;

namespace Covid_19_Application.Models
{
    public class WholeSummary
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public Global Global { get; set; }

        public List<CountryForSmry> Countries { get; set; }

        public string Date { get; set; }
    }


    public class Global
    {
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public string Date { get; }
    }
}
