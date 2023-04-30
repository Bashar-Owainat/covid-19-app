namespace Covid_19_Application.Models.DTOs
{
    public class MyRecord
    {
        public string ID { get; set; }
        public string Country { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public string Date { get; set; }
    }
}
