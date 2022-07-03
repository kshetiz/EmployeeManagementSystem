using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class PeopleViewModel
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
