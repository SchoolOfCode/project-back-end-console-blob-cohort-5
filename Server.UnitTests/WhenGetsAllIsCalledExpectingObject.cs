using FluentAssertions;
using Server.Controllers;
using Server.Models;
using Server.Data;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace Server.UnitTests
{
    public class WhenGetsAllIsCalledExpectingObject
    {
        private readonly CountryController _controller;

        private readonly List<CountryObj> _CountryObjs;

        public WhenGetsAllIsCalledExpectingObject()
        {
            _CountryObjs = new List<CountryObj>
            {
                new CountryObj
                {
                    WithinEng = "Allowed",
                    ToEnglandFromUK = "Allowed",
                    ToUkFromEngland = "Allowed",
                    IntFromEng = "Not allowed",
                    ToEngFromInt = "Allowed"
                }
            };

            var countryrepository = Substitute.For<IRepository>();
            countryrepository.GetAll().Returns(x => _CountryObjs);

            _controller = new CountryController(countryrepository);

        }

        [Fact]
        public void ThenAStatusCodeOf200IsReturned()
        {
            var result = _controller.GetAll();
            var statusCode =((OkObjectResult)result.Result).StatusCode;
            statusCode.Should().Be(200);
        }

         [Fact]

        public void OneObjectIsReturned()
        {
            var result = _controller.GetAll();
            var rulesObject = ((OkObjectResult)result.Result).Value as List<CountryObj>;
            rulesObject.Should().HaveCount(1);
        }

        [Fact]

        public void ObjectIsReturned()
        {
            var result = _controller.GetAll();
            var rulesObject = ((OkObjectResult)result.Result).Value as List<CountryObj>;
            rulesObject.Should().BeEquivalentTo(_CountryObjs);
        }
    

    }
}