using System;
using System.Collections.Generic;

namespace Final_examABC_Employee.Models
{
    public partial class Employees
    {
        public Employees()
        {
            JobAssignments = new HashSet<JobAssignments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<JobAssignments> JobAssignments { get; set; }
    }
}
