using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeProject.Models
{
    public partial class Employee
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Salary { get; set; }

        [Required]
        public string? PhoneNo { get; set; }

        [Required]
        public string? Address { get; set; }


        [ValidateNever]
       
        public int? DId { get; set; }
        [ForeignKey("DId")]

        [ValidateNever]
        public  TblDepartment? Department { get; set; }
    }
}
