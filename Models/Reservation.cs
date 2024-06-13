using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

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
