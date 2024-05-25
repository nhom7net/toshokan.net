namespace toshokan.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int BookID {  get; set; }
        public int MemberID {  get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Status {  get; set; }
        public Book Book { get; set; }  
        public Member Member { get; set; }
    }
}
