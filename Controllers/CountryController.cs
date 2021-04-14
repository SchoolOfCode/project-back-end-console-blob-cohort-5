using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Models;
using Server.Data;

namespace Server.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly IRepository<CountryObj> _countryRepository;

        public CountryController(IRepository<CountryObj> countryreository)
       {
           _countryRepository = countryreository;
       }

       [HttpGet]
       public ActionResult<IEnumerable<CountryObj>> GetAll()
       {
           var countryObjs = _countryRepository.GetAll();
           return Ok(countryObjs);
       }
      
    }
}
