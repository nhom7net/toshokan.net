using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Librarian
    {
        [Key]
        public int LibrarianID { get; set; }

        [StringLength(50, ErrorMessage = "First name can't be longer than 50 characters")]
        public string FirstName { get; set; }

 
        [StringLength(50, ErrorMessage = "Last name can't be longer than 50 characters")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")] 
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; }


        [StringLength(20, ErrorMessage = "Username can't be longer than 20 characters")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}