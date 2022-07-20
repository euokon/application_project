using ApplicationProject.Entities;
using ApplicationProject.Helper;
using ApplicationProject.Persistence;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationProject.Repository
{
    public class ApplicationProjectRepository : IApplicationProjectRepository
    {
        private readonly string _connectionString;
        public ApplicationProjectRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<ActionResponse> AddProjectData(ProjectData projectData)
        {
            var response = new ActionResponse();
            //bool response = false;

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "pkg_application_project.insert_application_projects",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                projectData.ProjectId = Guid.NewGuid().ToString().Replace("-", "");
                cmd.Parameters.Add("p_project_id", projectData.ProjectId);
                cmd.Parameters.Add("p_project_name", projectData.ProjectName);
                cmd.Parameters.Add("p_project_start_date", projectData.ProjectStartDate);
                cmd.Parameters.Add("p_expected_end_date", projectData.ExpectedEndDate);
                cmd.Parameters.Add("p_business_days", projectData.BusinessDays);
                cmd.Parameters.Add("p_created_by", projectData.CreatedBy);

                cmd.BindByName = true;
                await connection.OpenAsync();
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    response.Status = true;
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Message = ex.Message;
                }
            }
            return response;
        }

    }
}
