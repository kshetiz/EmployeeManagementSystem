using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeJobHistoryViewModel
    {
        [Key]
        public string EmployeeJobHistoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
    }

}
