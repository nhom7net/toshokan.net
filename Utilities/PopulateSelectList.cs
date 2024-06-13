using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Utilities
{
    public static class PopulateSelectList
    {
        public static SelectList BookList(toshokanContext context, object selected = null)
        {
            var booksQuery = from d in context.Book
                                   orderby d.Title
                                   select d;
            return new SelectList(booksQuery.AsNoTracking(), 
                nameof(Book.Id), 
                nameof(Book.Title), 
                selected);
        }
        public static SelectList MemberList(toshokanContext context, object selected = null)
        {
            var membersQuery = from d in context.Member
                             orderby d.FirstName
                             select new
                             {
                                 id = d.MemberID,
                                 fullName = d.FirstName + " " + d.LastName
                             };
            return new SelectList(
                membersQuery.AsNoTracking(), 
                "id", 
                "fullName", 
                selected);
        }
    }
}
