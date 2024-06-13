using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [Required]
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        public bool Returned { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookID { get; set; }

        public Book Book { get; set; }

        [Required]
        [ForeignKey("Member")]
        public int MemberID { get; set; }

        public Member Member { get; set; }
    }
}
