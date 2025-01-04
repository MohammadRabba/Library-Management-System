using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class BookNotAvailableException : Exception
    {
        public BookNotAvailableException(string title) { Console.WriteLine($"This Book {title} is Unavailable."); }
    }
    public class MembershipLimitExceededException : Exception
    {
        public MembershipLimitExceededException(Member m) { Console.WriteLine($"This Member {m.Name} exceeds his borrowing limit {m.BorrowingLimit} borrowed books for {m.MembershipType}"); }
    }


}
