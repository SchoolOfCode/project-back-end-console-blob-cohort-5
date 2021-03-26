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
        private readonly IRepository<CountryObj> _countryRepository;

        public CountryController(IRepository<CountryObj> countryreository)
       {
           _countryRepository=countryreository;
       }

       [HttpGet]
       public IEnumerable<CountryObj> GetAll(string search)
       {
           if(search !=null){
               return _countryRepository.Search(search);
           }
           return _countryRepository.GetAll();
       }
      
    }
}
