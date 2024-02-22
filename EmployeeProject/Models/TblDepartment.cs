using System;
using System.Collections.Generic;

namespace EmployeeProject.Models
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            Employees = new HashSet<Employee>();
        }

        public int DId { get; set; }
        public string? Department { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
