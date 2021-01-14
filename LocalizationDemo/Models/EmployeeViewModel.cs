using System;
using System.ComponentModel.DataAnnotations;

namespace LocalizationDemo.Models
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage ="FirstNameErrorMessage")]
        [Display(Name ="FirstName")] 
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastNameErrorMessage")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "SalaryErrorMessage")]
        [Display(Name = "Salary"), DisplayFormat(DataFormatString = "{0:n}")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "DOBErrorMessage")]
        [Display(Name = "DOB"), DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime DOB { get; set; }
    }
}