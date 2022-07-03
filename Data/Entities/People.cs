using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class People
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Employees Employees { get; set; }
    }
}
