using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsDisabled { get; set; } = false;
        public int PersonId { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
    }
}
