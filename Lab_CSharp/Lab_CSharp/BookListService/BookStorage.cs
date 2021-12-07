using System.Collections.Generic;
using Lab_CSharp.BookClass;

namespace Lab_CSharp.BookListService
{
    public class BookStorage
    {
        private List<Book> books;

        public bool IsEmpty()
        {
            return books.Count == 0;
        }
        public BookStorage()
        {
            books = new List<Book>();
        }

        public BookStorage(List<Book> books)
        {
            this.books = books;
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public void AddBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                this.books.Add(book);
            }
        }
    }
}
