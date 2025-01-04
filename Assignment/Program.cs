using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assignment2;

public class Program
{
    public static void Main(string[] args)
    {
        var library = new LibrarySystem();
        Manager manager1 = new Manager { ID = 1, Name = "Basil", MembershipType = MembershipType.Manager };
        Manager manager2 = new Manager { ID = 2, Name = "Mohammad", MembershipType = MembershipType.Manager };
        library.BookAction += manager1.HandleNotification;
        library.BookAction += manager2.HandleNotification;


        library.AddBook("C# Basics", "Author 1", "123");
        library.AddBook("Advanced C#", "Author 2", "456");
        library.AddBook("Data Structures", "Author 3", "789");
        library.AddBook("Algorithms", "Author 4", "101112");

        library.AddMember("Ahmad", MembershipType.Student);
        library.AddMember("Rami", MembershipType.Faculty);
        library.AddMember("Marah", MembershipType.Student);

        library.BorrowBook(1, "123");
        library.BorrowBook(2, "456");
        library.BorrowBook(2, "789");
        library.BorrowBook(3, "123");
        library.BorrowBook(1, "101112");
        library.ReturnBook(2, "789");

        //From Your Scenario in Assume that borrowed books for student Limit is 2 books
        library.BorrowBook(1, "789");
        library.BorrowBook(99, "123");
        library.ReturnBook(1, "123");
        library.ReturnBook(2, "456");
        library.BorrowBook(3, "123");
    }
}
