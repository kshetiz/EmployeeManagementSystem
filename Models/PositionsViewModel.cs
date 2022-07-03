using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class PositionsViewModel
    {
        [Key]
        public int PostionId { get; set; }
        public string PositionName { get; set; }
    }
}
