using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class Employees
    {
        [Key]

        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployeeCode { get; set; }
        public bool IsDisabled { get; set; }
        public int PersonId { get; set; }
        public int PositionId { get; set; }
        public  People People { get; set; }
        public ICollection <Positions> Positions { get; set; }

    }
}
