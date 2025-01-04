Library Management System
Project Overview
Your task is to develop a Library Management System that allows users (students, Faculty) to manage book borrowings, returns, and view available books. The system should also support the management of library memberships and overdue fines.
It demonstrates an understanding of OOP principles while utilizing various C# features: generic collections, generics, delegates, extension methods, LINQ, events, and exceptions.
Business Requirements
1.	Book Management
a.	Add new books to the library.
b.	View all available books.
c.	Search for books by title, author using LINQ.
d.	Ensure each book has the following attributes: 
i.	Title
ii.	Author
iii.	ISBN
iv.	Availability status
2.	Membership Management
a.	The member should have a unique ID, Name, and Membership Type.
b.	Members can have a borrowing limit (e.g., Students can borrow up to 3 books, Faculty can borrow up to 5 books).
c.	Add new members.

3.	Borrowing and Returning Books
a.	A member can borrow an available book.
b.	Track borrowed books using a dictionary where the key is the member ID, and the value is a list of borrowed book titles.
c.	Allow members to return books.

4.	Library Managers
a.	They must be notified whenever a book is borrowed or returned.
Technical Requirements
Generics
The system must use a generic repository to manage data sets for various classes.

1.	Create a generic class Repository<T> for managing collections, it must support the following operations:
❖	Add an item.
❖	Remove an item.
❖	Retrieve all items.
2.	Write a generic method FindItems<T> that filters a list of items based on a predicate.
3.	Implement a generic interface IRepository<T> to define the methods for the repository.
Generic Collections
LibrarySystemClass:
1.	Use the generic repository to store all books in the library.
2.	Use the generic repository to store all members of the library.
3.	Use a Dictionary<int, List<string>> to manage borrowed books, where the key is the member ID, and the value is a list of borrowed book titles.
●	 implement the following methods: 
o	Search for books by title
o	Search for books by author
o	AddBook : Add new books  to the system.
o	AddMember: Add new members to the system.
o	BorrowBook(int memberId, string isbn): Allows a member to borrow a book while checking availability and borrowing limits.
The system must allow members to borrow books if:
♦	The book is available.
♦	The member has not exceeded their borrowing limit.
♦	Borrowed books must be tracked by member ID.
♦	Trigger a BookBorrowed event with the book title.

o	ReturnBook(int memberId, string isbn): Marks a book as returned and removes it from the member’s borrowed list.
       The system must allow members to return borrowed books.
♦	The returned book's availability must be restored.
♦	Trigger a BookReturned event with the book title.
Extension Methods
●	Write an extension method for the Repository<Book> collection to get all available books only.
●	Write an extension method for Dictionary<int, List<string>> to retrieve all borrowed books by a specific member ID.
Events
●	Define an event BookBorrowed that triggers when a book is borrowed.
That will notify the Managers that the book is borrowed

●	Define an event BookReturned that triggers when a book is returned.
That will notify the Managers that the book is returned

●	The Managers Class will have method to handle these notifications
It will handle them by print the Manager information's (ID, Name), the operation type (Borrow/Return) and the book title

Exceptions
●	Throw a custom exception BookNotAvailableException when a member tries to borrow a book that is unavailable.
●	Throw a custom exception MembershipLimitExceededException when a member exceeds their borrowing limit.
 Main Method Scenario
1.	Library Initialization:
a.	A LibrarySystem is created.
b.	Create 2 Managers

2.	Adding Books and Members:
a.	Four books are added:
i.	C# Basics (ISBN: 123) and Advanced C# (ISBN: 456) 
ii.	Data Structures (ISBN: 789) and Algorithms (ISBN: 101112)
b.	Three members are added:
i.	Ahmad (Student, ID: 1), Rami (Faculty, ID: 2), and Marah (Student, ID: 3).
3.	Borrowing Books:
a.	Ahmad borrows C# Basics (ISBN: 123) successfully.
b.	Rami borrows Advanced C# (ISBN: 456) and Data Structures (ISBN: 789), utilizing part of his higher borrowing limit.
c.	Marah tries to borrow C# Basics but fails because it’s already borrowed by Ahmad (throws BookNotAvailableException).
d.	Ahmad borrows Algorithms (ISBN: 101112), reaching his student borrowing limit.
4.	Validation and Errors:
a.	Ahmad attempts to borrow Data Structures but fails due to exceeding his borrowing limit (throws MembershipLimitExceededException).
b.	A non-existent member (ID: 99) tries to borrow a book, resulting in a "Member not found" error.
5.	Returning Books:
a.	Ahmad returns C# Basics, making it available again. 
b.	Rami returns Advanced C#, freeing up his limit.
6.	Reattempted Borrowing:
a.	Marah successfully borrows C# Basics after Ahmad returns it.

        7.  The Managers Must be notified about every borrow or return operation
