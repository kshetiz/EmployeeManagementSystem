using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeViewModel
    {

        public string PersonId { get; set; }
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsDisabled { get; set; } = false;
        public string PositionId { get; set; }
        public string EmployeeJobHistoryId { get; set; }
    }
}
