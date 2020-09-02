using EmployeeManagement_Models;
using EmployeeManagement_Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name field cannot be empty")]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name field cannot be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email field cannot be empty")]

        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Invalid email address")]
        [EmailDomainValidator(AllowedDomain = "Company.com",
            ErrorMessage = "Email domain must be type of Company.com")]
        
        public string Email { get; set; }
        [CompareProperty("Email",ErrorMessage ="Email an confirm email not match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
