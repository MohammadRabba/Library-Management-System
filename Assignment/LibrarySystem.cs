using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{

    public class LibrarySystem
    {
        public Repository<Book> Books { get; } = new Repository<Book>();
        public Repository<Member> Members { get; } = new Repository<Member>();
        public Dictionary<int, List<string>> BorrowedBooks = new Dictionary<int, List<string>>();

        public event Action<string, string> BookAction;

        public void AddMember(string name, MembershipType type)
        {
            var newMember = new Member(name, type);
            Members.AddNewItem(newMember);
        }
        public void AddBook(string title, string author, string isbn)
        {
            var newMember = new Book { Title = title, Author = author, ISBN = isbn };
            Books.AddNewItem(newMember);
        }
        public void BorrowBook(int memberId, string isbn)
        {
            try
            {
                var member = Members.GetAllItems().FirstOrDefault(m => m.ID == memberId);
                if (member == null) throw new Exception($"Member with Id {memberId} Not Found.");

                var book = Books.FindItems(b => b.ISBN == isbn).FirstOrDefault();
                if (book == null) throw new Exception($"Book Not Found {isbn}");

                if (!book.IsAvailable) throw new BookNotAvailableException(book.Title);

                if (!BorrowedBooks.ContainsKey(memberId))
                    BorrowedBooks[memberId] = new List<string>();
                if (BorrowedBooks[memberId].Count >= member.BorrowingLimit)
                {
                    throw new MembershipLimitExceededException(member);
                }
                book.IsAvailable = false;
                BorrowedBooks[memberId].Add(book.Title);
                BookAction.Invoke("Borrowed", book.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReturnBook(int memberId, string isbn)
        {
            try
            {
                var book = Books.GetAllItems().FirstOrDefault(m => m.ISBN == isbn);
                if (book == null)
                {
                    throw new Exception("Book not found.");
                }

                if (BorrowedBooks.ContainsKey(memberId) && BorrowedBooks[memberId].Contains(book.Title))
                {
                    BorrowedBooks[memberId].Remove(book.Title);
                    book.IsAvailable = true;
                    BookAction.Invoke("Returned", book.Title);
                }
                else
                {
                    throw new Exception("Book is not borrowed by this member.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
