using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class EmployeeJobHistory
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
