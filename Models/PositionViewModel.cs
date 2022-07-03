using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class PositionViewModel
    {
        [Key]
        public string PositionId { get; set; }
        public string PositionName { get; set; }
    }
}
