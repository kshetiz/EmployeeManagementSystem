using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class Positions
    {
        [Key]
        public int PostionId { get; set; }
        public string PositionName { get; set; }
    }
}
