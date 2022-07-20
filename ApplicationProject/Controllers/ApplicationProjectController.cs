using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationProject.Entities;
using ApplicationProject.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationProject.Controllers
{
    [Route("api/apps-project")]
    [ApiController]
    public class ApplicationProjectController : ControllerBase
    {
        private readonly IApplicationProjectRepository _applicationProjectRepository;
        private readonly ITestDataMethods _testDataMethods;
        private string _userId;
        public ApplicationProjectController(IApplicationProjectRepository applicationProjectRepository, ITestDataMethods testDataMethods)
        {
            _applicationProjectRepository = applicationProjectRepository;
            _testDataMethods = testDataMethods;
            _userId = "oyukor";
        }

        [HttpPost("add-project-data")]
        public async Task<ActionResult> AddProjectData(ProjectData projectData)
        {
            projectData.CreatedBy = _userId;
            projectData.BusinessDays = _testDataMethods.DateRangeValue(projectData.ProjectStartDate, projectData.ExpectedEndDate);
            var response = await _applicationProjectRepository.AddProjectData(projectData).ConfigureAwait(false);
            if (response.Status)
                return Ok();
            return BadRequest();
        }
    }
}