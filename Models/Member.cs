using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Member
    {
        [Key]
        public int MemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime MembershipDate { get; set; }
    }
}
