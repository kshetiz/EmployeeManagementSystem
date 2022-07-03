using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class Position
    {
        [Key]
        public string PositionId { get; set; }
        public string PositionName { get; set; }
        public ICollection<Employee> Employee { get; set; }

    }
}
