using Covid_19_Application.Models.DTOs;
using System.Collections.Generic;

namespace Covid_19_Application.Models
{
    public class CountryAndTotal
    {
        public WorldTotal worldTotal { get; set; }
        public IEnumerable<SpecificCountryDTO> countryDto { get; set; }
    }
}
