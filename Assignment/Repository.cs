using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Assignment2
{

    public class Repository<T> : IRepository<T>
    {
        private List<T> items = new List<T>();

        public void AddNewItem(T item) { items.Add(item); }
        public void RemoveItem(T item) { items.Remove(item); }
        public List<T> GetAllItems() { return items; }
        public List<T> FindItems(Func<T, bool> predicate) {

            return items.Where(predicate).ToList(); }


        public  List<Book> SearchBooks( Repository<Book> books, string intrey)
        { 
            return books.GetAllItems()
                .Where(b => b.ISBN.Equals(intrey) || b.Title.Equals(intrey) || b.Author.Equals(intrey)).ToList();
        }

    }
}