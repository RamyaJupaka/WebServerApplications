using System;
using System.Collections.Generic;

namespace Final_examABC_Employee.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            JobAssignments = new HashSet<JobAssignments>();
        }

        public string JobCode { get; set; }
        public string JobTtile { get; set; }
        public string StartDate { get; set; }

        public virtual ICollection<JobAssignments> JobAssignments { get; set; }
    }
}
