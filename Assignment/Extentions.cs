using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public static class RepositoryExtensions
    {
        public static List<Book> GetAvailableBooks(this Repository<Book> books)
        {
            return books.GetAllItems().Where(b => b.IsAvailable).ToList();
        }
        public static List<string> GetBorrowedBooksByMember(this Dictionary<int, List<string>> borrowedBooks, int Id)
        {
            if (borrowedBooks.ContainsKey(Id))
            {
                return borrowedBooks[Id];
            }
            { return new List<string>(); }
        }
    }
}
