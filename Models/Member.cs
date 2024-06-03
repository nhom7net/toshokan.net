namespace toshokan.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Address {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }
        public DateTime MembershipDate { get; set; }
        ICollection<Loan> Loans { get; set; }
        ICollection<Reservation> Reservations {  get; set; }    
    }
}
