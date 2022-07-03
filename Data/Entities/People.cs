using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Entities
{
    public class People
    {
        [Key]
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Employee Employee { get; set; }
    }
}
