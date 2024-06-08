using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Utilities
{
    public static class PopulateSelectList
    {
        public static SelectList bookList(toshokanContext context, object selected = null)
        {
            var booksQuery = from d in context.Book
                                   orderby d.Title
                                   select d;
            return new SelectList(booksQuery.AsNoTracking(), "Id", "Id", selected);
        }
        public static SelectList memberList(toshokanContext context, object selected = null)
        {
            var membersQuery = from d in context.Member
                             orderby d.FirstName
                             select d;
            return new SelectList(membersQuery.AsNoTracking(), "MemberID", "MemberID", selected);
        }
    }
}
