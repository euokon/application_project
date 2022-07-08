using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationProject.Entities
{
    public class ProjectData
    {
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public char CompletionStatus { get; set; }
        public double BusinessDays { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string ModifiedBy { get; set; }
    }


}
