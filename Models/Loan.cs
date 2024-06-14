using System;
using System.ComponentModel.DataAnnotations;

namespace toshokan.Models
{
    public class Loan
    {
        [Key]
        public int LoanID { get; set; }

        [Required(ErrorMessage = "Loan date is required")]
        [DataType(DataType.Date)]
        public DateTime LoanDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Required(ErrorMessage = "Returned status is required")]
        public bool Returned { get; set; }

       
        public Book Book { get; set; }

      
        public Member Member { get; set; }
    }
}
