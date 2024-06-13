using toshokan.Models;

namespace toshokan.Data;

public static class DbInitializer
{
    public static void Initialize(toshokanContext context)
    {
        // data exist
        if (context.Book.Any()) return;
        
        var books = new List<Book>()
        {
            new Book { Id = 1, Title = "The Lord of the Rings: The Fellowship of the Ring", Author = "J. R. R. Tolkien", Genre = "Fantasy", CopiesAvailable = 10, PublishedDate = DateTime.Parse("2023-01-01"), ImgURL = "https://1.bp.blogspot.com/-3Qr51FbCt7A/UP-ccYH1e0I/AAAAAAAAA2w/2aM1a9ZcBnk/s1600/the-lord-of-the-rings-fellowship-of-the-rings_1.jpg"},
            new Book { Id = 2, Title = "The Alchemist", Author = "Paulo Coelho", Genre = "Fantasy", CopiesAvailable = 5, PublishedDate = DateTime.Parse("2022-12-01"), ImgURL = "https://dailytimes.com.pk/assets/uploads/2021/07/06/the-alchemist-a-graphic-novel-1017x1536.jpg"},
            new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction", CopiesAvailable = 8, PublishedDate = DateTime.Parse("2024-01-01"), ImgURL = "https://cdn2.penguin.com.au/covers/original/9781784752637.jpg"},
            new Book { Id = 4, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", Genre = "Science Fiction", CopiesAvailable = 3, PublishedDate = DateTime.Parse("2023-02-01"), ImgURL = "https://4.bp.blogspot.com/_KFxmlXHAk1A/TT3xWKVzB9I/AAAAAAAACTE/NE4KyvH94ys/s1600/hitchhikers_guide_to_the_galaxy_v1.jpg"},
            new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J. D. Salinger", Genre = "Coming-of-Age", CopiesAvailable = 7, PublishedDate = DateTime.Parse("2024-03-01"), ImgURL = "https://i1.wp.com/bookstoker.com/wp-content/uploads/2019/03/The-Catcher-in-the-Rye-by-J.D.-Salinger.jpeg?fit=1089,1600&ssl=1"},
            new Book { Id = 6, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Fiction", CopiesAvailable = 2, PublishedDate = DateTime.Parse("2023-04-01"), ImgURL = "https://image.tmdb.org/t/p/original/ddzcKLZsz1Z3eGvSTrFYxFfCiJq.jpg"},
            new Book { Id = 7, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance", CopiesAvailable = 9, PublishedDate = DateTime.Parse("2022-11-01"), ImgURL = "https://image.tmdb.org/t/p/original/vAxWpk857xbpaeoSvkRsfMbokPl.jpg"},
            new Book { Id = 8, Title = "Animal Farm", Author = "George Orwell", Genre = "Allegory", CopiesAvailable = 4, PublishedDate = DateTime.Parse("2024-02-01"), ImgURL = "https://upload.wikimedia.org/wikipedia/commons/f/fb/Animal_Farm_-_1st_edition.jpg"},
            new Book { Id = 9, Title = "The Book Thief", Author = "Markus Zusak", Genre = "Historical Fiction", CopiesAvailable = 6, PublishedDate = DateTime.Parse("2023-03-01"), ImgURL = "https://lumiere-a.akamaihd.net/v1/images/image_7324f2be.jpeg?region=0,0,1400,2100"},
            new Book { Id = 10, Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Genre = "Magical Realism", CopiesAvailable = 1, PublishedDate = DateTime.Parse("2022-10-01"), ImgURL = "https://interactive.wttw.com/sites/default/files/one-hundred-years-of-solitude@2x.jpg"},
        };
        
        context.Book.AddRange(books);
        context.SaveChanges();
        
        
        var members = new List<Member>()
        {
            new Member { FirstName = "John", LastName = "Doe", Address = "123 Main St", PhoneNumber = "555-555-5555", Email = "john.doe@example.com", MembershipDate = DateTime.Now.AddDays(-30) },
            new Member { FirstName = "Jane", LastName = "Smith", Address = "456 Elm St", PhoneNumber = "123-456-7890", Email = "jane.smith@example.com", MembershipDate = DateTime.Now.AddDays(-10) },
            new Member { FirstName = "Michael", LastName = "Williams", Address = "789 Oak Ave", PhoneNumber = "987-654-3210", Email = "michael.williams@example.com", MembershipDate = DateTime.Now },
            new Member { FirstName = "Sarah", LastName = "Jones", Address = "1011 Maple Dr", PhoneNumber = "505-246-8135", Email = "sarah.jones@example.com", MembershipDate = DateTime.Now.AddMonths(-1) },
            new Member { FirstName = "David", LastName = "Miller", Address = "1213 Pine Blvd", PhoneNumber = "360-789-5421", Email = "david.miller@example.com", MembershipDate = DateTime.Now.AddMonths(-2) },
            new Member { FirstName = "Emily", LastName = "Brown", Address = "1415 Spruce Ln", PhoneNumber = "212-555-1212", Email = "emily.brown@example.com", MembershipDate = DateTime.Now.AddMonths(-3) },
            new Member { FirstName = "Matthew", LastName = "Garcia", Address = "1617 Birch Rd", PhoneNumber = "703-421-8765", Email = "matthew.garcia@example.com", MembershipDate = DateTime.Now.AddMonths(-4) },
            new Member { FirstName = "Jennifer", LastName = "Hernandez", Address = "1819 Poplar St", PhoneNumber = "415-987-3210", Email = "jennifer.hernandez@example.com", MembershipDate = DateTime.Now.AddMonths(-5) },
            new Member { FirstName = "Christopher", LastName = "Lopez", Address = "2021 Willow Way", PhoneNumber = "818-369-1578", Email = "christopher.lopez@example.com", MembershipDate = DateTime.Now.AddMonths(-6) },
            new Member { FirstName = "Amanda", LastName = "Clark", Address = "2223 Elm St", PhoneNumber = "617-258-9471", Email = "amanda.clark@example.com", MembershipDate = DateTime.Now.AddMonths(-7) },
        };

        context.Member.AddRange(members);
        context.SaveChanges();
        
        var librarians = new List<Librarian>()
        {
            new Librarian { FirstName = "Alice", LastName = "Thompson", PhoneNumber = "206-555-1234", Email = "alice.thompson@library.com", EmploymentDate = DateTime.Now.AddYears(-2) },
            new Librarian { FirstName = "Ben", LastName = "Johnson", PhoneNumber = "415-789-4567", Email = "ben.johnson@library.com", EmploymentDate = DateTime.Now.AddMonths(-6) },
            new Librarian { FirstName = "Charles", LastName = "Garcia", PhoneNumber = "310-246-8100", Email = "charles.garcia@library.com", EmploymentDate = DateTime.Now.AddDays(-30) },
            new Librarian { FirstName = "Diana", LastName = "Lee", PhoneNumber = "617-369-7852", Email = "diana.lee@library.com", EmploymentDate = DateTime.Now.AddMonths(-3) },
            new Librarian { FirstName = "Edward", LastName = "Miller", PhoneNumber = "502-987-1215", Email = "edward.miller@library.com", EmploymentDate = DateTime.Now.AddMonths(-7) },
        };
        
        context.Librarian.AddRange(librarians);
        context.SaveChanges();
        
        var loans = new List<Loan>()
        {
            new Loan { LoanDate = DateTime.Now.AddDays(-14), Returned = true, ReturnDate = DateTime.Now.AddDays(-7), Book = context.Book.FirstOrDefault(b => b.Id == 1), Member = context.Member.FirstOrDefault(m => m.MemberID == 1) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-2), Returned = false, Book = context.Book.FirstOrDefault(b => b.Id == 2), Member = context.Member.FirstOrDefault(m => m.MemberID == 2) },
            new Loan { LoanDate = DateTime.Now.AddDays(-10), Returned = true, ReturnDate = DateTime.Now, Book = context.Book.FirstOrDefault(b => b.Id == 3), Member = context.Member.FirstOrDefault(m => m.MemberID == 3) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-3), Returned = false, Book = context.Book.FirstOrDefault(b => b.Id == 4), Member = context.Member.FirstOrDefault(m => m.MemberID == 4) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-1), Returned = true, ReturnDate = DateTime.Now.AddDays(-15), Book = context.Book.FirstOrDefault(b => b.Id == 5), Member = context.Member.FirstOrDefault(m => m.MemberID == 5) },
            new Loan { LoanDate = DateTime.Now.AddDays(-5), Returned = false, Book = context.Book.FirstOrDefault(b => b.Id == 6), Member = context.Member.FirstOrDefault(m => m.MemberID == 1) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-4), Returned = true, ReturnDate = DateTime.Now.AddMonths(-2), Book = context.Book.FirstOrDefault(b => b.Id == 7), Member = context.Member.FirstOrDefault(m => m.MemberID == 2) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-2), Returned = false, Book = context.Book.FirstOrDefault(b => b.Id == 8), Member = context.Member.FirstOrDefault(m => m.MemberID == 3) },
            new Loan { LoanDate = DateTime.Now.AddDays(-2), Returned = false, Book = context.Book.FirstOrDefault(b => b.Id == 9), Member = context.Member.FirstOrDefault(m => m.MemberID == 4) },
            new Loan { LoanDate = DateTime.Now.AddMonths(-3), Returned = true, ReturnDate = DateTime.Now.AddDays(-20), Book = context.Book.FirstOrDefault(b => b.Id == 10), Member = context.Member.FirstOrDefault(m => m.MemberID == 5) },
        };
        
        context.Loan.AddRange(loans);
        context.SaveChanges();
        
        var reservations = new List<Reservation>()
        {
            new Reservation { ReservationDate = DateTime.Now, ExpirationDate = DateTime.Now.AddDays(7), Status = "Pending", Book = context.Book.FirstOrDefault(b => b.Id == 1), Member = context.Member.FirstOrDefault(m => m.MemberID == 2) },
            new Reservation { ReservationDate = DateTime.Now.AddDays(-5), ExpirationDate = DateTime.Now.AddDays(2), Status = "Approved", Book = context.Book.FirstOrDefault(b => b.Id == 3), Member = context.Member.FirstOrDefault(m => m.MemberID == 4) },
            new Reservation { ReservationDate = DateTime.Now.AddMonths(-1), ExpirationDate = DateTime.Now.AddDays(-1), Status = "Expired", Book = context.Book.FirstOrDefault(b => b.Id == 5), Member = context.Member.FirstOrDefault(m => m.MemberID == 1) },
            new Reservation { ReservationDate = DateTime.Now.AddDays(-3), ExpirationDate = DateTime.Now.AddMonths(1), Status = "Pending", Book = context.Book.FirstOrDefault(b => b.Id == 7), Member = context.Member.FirstOrDefault(m => m.MemberID == 3) },
            new Reservation { ReservationDate = DateTime.Now.AddMonths(-1), ExpirationDate = DateTime.Now, Status = "Cancelled", Book = context.Book.FirstOrDefault(b => b.Id == 9), Member = context.Member.FirstOrDefault(m => m.MemberID == 5) },
            new Reservation { ReservationDate = DateTime.Now, ExpirationDate = DateTime.Now.AddDays(10), Status = "Pending", Book = context.Book.FirstOrDefault(b => b.Id == 2), Member = context.Member.FirstOrDefault(m => m.MemberID == 1) },
            new Reservation { ReservationDate = DateTime.Now.AddDays(-10), ExpirationDate = DateTime.Now.AddDays(5), Status = "Approved", Book = context.Book.FirstOrDefault(b => b.Id == 4), Member = context.Member.FirstOrDefault(m => m.MemberID == 2) },
            new Reservation { ReservationDate = DateTime.Now.AddMonths(-2), ExpirationDate = DateTime.Now.AddDays(14), Status = "Pending", Book = context.Book.FirstOrDefault(b => b.Id == 6), Member = context.Member.FirstOrDefault(m => m.MemberID == 4) },
            new Reservation { ReservationDate = DateTime.Now.AddDays(-4), ExpirationDate = DateTime.Now.AddMonths(2), Status = "Pending", Book = context.Book.FirstOrDefault(b => b.Id == 8), Member = context.Member.FirstOrDefault(m => m.MemberID == 3) },
            new Reservation { ReservationDate = DateTime.Now.AddMonths(-2), ExpirationDate = DateTime.Now.AddMonths(-1), Status = "Expired", Book = context.Book.FirstOrDefault(b => b.Id == 10), Member = context.Member.FirstOrDefault(m => m.MemberID == 5) },
        };
        
        context.Reservation.AddRange(reservations);
        context.SaveChanges();
    }
}