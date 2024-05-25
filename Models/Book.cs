namespace toshokan.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public string Genre {  get; set; }
        public int CopiesAvailable {  get; set; }
        public DateTime PublishedDate {  get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
