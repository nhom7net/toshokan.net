using System;
using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
         
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime MembershipDate { get; set; }


        [StringLength(30, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

    
      
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}