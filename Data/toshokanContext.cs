using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;

namespace toshokan.Data
{
    public class toshokanContext : DbContext
    {
        public toshokanContext (DbContextOptions<toshokanContext> options)
            : base(options)
        {
        }

        public DbSet<toshokan.Models.Book> Book { get; set; } = default!;
        public DbSet<toshokan.Models.Librarian> Librarian { get; set; } = default!;
        public DbSet<toshokan.Models.Loan> Loan { get; set; } = default!;
        public DbSet<toshokan.Models.Member> Member { get; set; } = default!;
        public DbSet<toshokan.Models.Reservation> Reservation { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Librarian>().ToTable("Librarian");
            modelBuilder.Entity<Loan>().ToTable("Loan");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
        }
    }
}
