using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class Employee
    {
        [Key]
        
        public string EmployeeId { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeeCode { get; set; }
        [DefaultValue("false")]
        public bool IsDisabled { get; set; }
        public string PersonId { get; set; }
        public People People { get; set; }
        public string PositionId { get; set; }
        public Position Position {get;set;}

    }
}
