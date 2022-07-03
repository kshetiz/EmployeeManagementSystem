using System.ComponentModel.DataAnnotations;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeJobHisstories
    {
        [Key]
        public int EmployeeJobHistoryId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Positions Positions { get; set; }
    }
}
