using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
//using Newtonsoft.Json;
using System.DataTransferObject;
//using O_NATION.DbContext;
using System.Models;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;

namespace System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
   
  private readonly O_NATIONContext _context;


        public CountryController(O_NATIONContext context)
        {
            _context = context;
        }


        [HttpGet("Search")]
        public IActionResult Search(string title)
        {

            var contries = _context.Countries.Where(b => b.CountryName.Contains(title));


            if (contries != null)
            {
                return Ok(contries);
            }
            return BadRequest("Not found");
             }
        //var countries = _context.
        //    SearchCountries(title);
        //List<CountryDto> courseDtos = new List<CountryDto>();
        //foreach (Country country in countries)
        //{
        //    CountryDto countryDto = new CountryDto();
        //    countryDto.countryId = country.CountryId;
        //    countryDto.countryName = country.CountryName;
        //    countryDto.countryNotes = country.CountryNotes;

        //    countryDto.Add(countryDto);

        //}


        //return Ok(JsonConvert.SerializeObject(countryDto));

        private List<Country> countries = new List<Country>
    {
       new Country { CountryId = 1, CountryName = "الكويت", CountryContinent = "آسيا" },
        new Country { CountryId = 2, CountryName = "السعودية", CountryContinent = "آسيا" },
        new Country { CountryId = 3, CountryName = "كوريا", CountryContinent = "آسيا" },
        new Country { CountryId = 4, CountryName = "البرتغال", CountryContinent = "أوروبا" },
        new Country { CountryId = 5, CountryName = "تركيا", CountryContinent = "آسيا" },
        new Country { CountryId = 6, CountryName = "اليابان", CountryContinent = "آسيا" },
        new Country { CountryId = 7, CountryName = "اسبانيا", CountryContinent = "أوروبا" },
        new Country { CountryId = 8, CountryName = "روسيا", CountryContinent = "آسيا" },
        new Country { CountryId = 9, CountryName = "كندا", CountryContinent = "أمريكا الشمالية" },
        new Country { CountryId = 10, CountryName = "فلسطين الحرة", CountryContinent = "آسيا" },
        // Add more countries here
   
    };
        [HttpGet]
        public IEnumerable<Country> GetCountriesByContinent(string continent)
        {
            return countries.Where(c => c.CountryContinent.Equals(continent, StringComparison.OrdinalIgnoreCase));
        }
    }
}

   

       
    