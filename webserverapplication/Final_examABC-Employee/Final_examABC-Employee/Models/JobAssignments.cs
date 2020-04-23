using System;
using System.Collections.Generic;

namespace Final_examABC_Employee.Models
{
    public partial class JobAssignments
    {
        public int JobAssignmentsId { get; set; }
        public string JobCode { get; set; }
        public int Id { get; set; }
        public string AssignemtDate { get; set; }

        public virtual Employees IdNavigation { get; set; }
        public virtual Jobs JobCodeNavigation { get; set; }
    }
}
