using EmployeeProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeProject.ViewModels
{
    public class EmployeeVM
    {

        public Employee? Employee { get; set; }
       

        public IEnumerable<SelectListItem>? DepartmentList { get;set; }
    }
}
