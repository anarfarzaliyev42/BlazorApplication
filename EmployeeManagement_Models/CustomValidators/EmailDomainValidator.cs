using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement_Models.CustomValidators
{
    public class EmailDomainValidator:ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.ToString().Contains("@"))
            {
                string[] strings = value.ToString().Split("@");
                if (strings[1].ToUpper() == AllowedDomain.ToUpper())
                {
                    return null;
                }
                return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            }

            return new ValidationResult("Invalid Email Format. Example:example@company.com", new[] { validationContext.MemberName });

        }
    }
}
