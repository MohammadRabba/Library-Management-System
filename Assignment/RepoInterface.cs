using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public interface IRepository<T>
    {
        void AddNewItem(T item);
        void RemoveItem(T item);
        List<T> GetAllItems();
        List<T> FindItems(Func<T, bool> predicate);
        List<Book> SearchBooks(Repository<Book> books, string intrey);

    }
}
