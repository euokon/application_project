using ApplicationProject.Entities;
using ApplicationProject.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationProject.Persistence
{
    public interface IApplicationProjectRepository
    {
        Task<ActionResponse> AddProjectData(ProjectData projectData);
    }
}
