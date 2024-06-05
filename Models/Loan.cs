namespace toshokan.Models
{
    public class Loan
    {
        public int LoanID { get; set; } 
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned {  get; set; }
        public Book Book { get; set; }
        public Member Member { get; set; } 
    }
}
