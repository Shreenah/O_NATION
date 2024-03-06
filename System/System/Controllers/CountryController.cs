using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
//using Newtonsoft.Json;
using System.DataTransferObject;
//using O_NATION.DbContext;
using System.Models;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;


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

        }
    }
}

