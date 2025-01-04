using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Manager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public MembershipType MembershipType { get; set; }
        public void HandleNotification(string operation, string bookTitle)
        {
            Console.WriteLine($" Manager {Name} with ID  => New Update for book {bookTitle} that this book {operation}");
        }
    }
}