//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace ontion.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountrGroupController : ControllerBase
//    {
//        private List<Country> countries = new List<Country>
//        {
//        new Country { CountryId = 1, CountryGroup1= "دول عربية"},
//        new Country { CountryId = 2, CountryGroup1 = "دول عربية"},
//        new Country { CountryId = 10, CountryGroup1 = "دول عربية"},
//        // Add more countries here
//    };

//    }
//}





////        [HttpGet]
////        public IEnumerable<Country> GetCountriesByGroup(string CountryGroup1)
////        {
////            return countries.Where(c => c.CountryGroup1.Equals(CountryGroup1, StringComparison.OrdinalIgnoreCase));
////        }
////    }
////}