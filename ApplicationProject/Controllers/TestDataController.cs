using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationProject.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationProject.Controllers
{
    [Route("api/test-data")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        private readonly ITestDataMethods _testDataMethods;
        public TestDataController(ITestDataMethods testDataMethods)
        {
            _testDataMethods = testDataMethods;
        }

        [HttpGet("business-days/{startDate}/{endDate}")]
        public double BusinessDays(DateTime startDate, DateTime endDate)
        {
            double busDays = 0;
            busDays = _testDataMethods.DateRangeValue(startDate, endDate);

            return busDays;
        }
    }
}