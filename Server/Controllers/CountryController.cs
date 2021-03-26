using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryController(IRepository<Country> countryreository)
       {
           _countryRepository=countryreository;
       }

       [HttpGet]
       public IEnumerable<Country> GetAll(string search)
       {
           if(search !=null){
               return _countryRepository.Search(search);
           }
           return _countryRepository.GetAll();
       }
      
    }
}
