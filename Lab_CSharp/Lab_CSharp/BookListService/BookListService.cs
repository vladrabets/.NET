using System;
using System.Collections.Generic;
using System.Linq;
using Lab_CSharp.BookClass;

namespace Lab_CSharp.BookListService
{
    public class BookListService
    {
        private Dictionary<int, Book> BookList = new Dictionary<int, Book>();

        public Dictionary<int, Book> GetBookList()
        {
            return BookList;
        }

        public bool IsEmpty()
        {
            return BookList.Count == 0;
        }

        public void Add(Book book)
        {
            if (BookList.Count == 0)
            {
                BookList.Add(0, book);
            } 
            else if (!BookList.ContainsValue(book))
            {
                BookList.Add(BookList.Count, book);
            } 
            else
            {
                throw new Exception("This book is already stored.");
            }
        }

        public void Remove(Book book)
        {
            if (BookList.Count == 0)
            {
                return;
            } 
            else if (BookList.ContainsValue(book))
            {
                int bookToRemoveKey = -1;
                
                foreach (var pair in BookList.Where(pair => pair.Value == book))
                {
                    bookToRemoveKey = pair.Key;
                    break;
                }

                BookList.Remove(bookToRemoveKey);
                return;
            }
            
            throw new Exception("Failed to remove the book. The book is out of storage.");
        }
        public List<Book> FindByAuthor(string author)
        {
            return (from pair in BookList where pair.Value.Author.Equals(author) select pair.Value).ToList();
        }

        public List<Book> FindByTitle(string title)
        {
            return (from pair in BookList where pair.Value.Title.Equals(title) select pair.Value).ToList();
        }

        public List<Book> FindByPublisher(string publisher)
        {
            return (from pair in BookList where pair.Value.Publisher.Equals(publisher) select pair.Value).ToList();
        }
        public List<Book> GetByAuthor()
        {
            List<Book> books = BookList.Select(pair => pair.Value).ToList();

            books.Sort(new BookAuthorComparator().Compare);
            return books;
        }

        public List<Book> GetByPages()
        {
            List<Book> books = BookList.Select(pair => pair.Value).ToList();

            books.Sort(new BookPagesComparator().Compare);
            return books;
        }

        public List<Book> GetByPrice()
        {
            List<Book> books = BookList.Select(pair => pair.Value).ToList();

            books.Sort(new BookPriceComparator().Compare);
            return books;
        }

        public void Load(BookStorage bookStorage)
        {
            if (BookList.Count == 0)
            {
                List<Book> books = bookStorage.GetBooks();

                for (int i = 0; i < books.Count; i++)
                {
                    BookList.Add(i, books[i]);
                }
            }
            else
            {
                List<Book> books = bookStorage.GetBooks();
                int count = BookList.Count;

                for (int i = 0; i < books.Count; i++)
                {
                    BookList.Add(i + count, books[i]);
                }
            }
        }
        public void Save(BookStorage bookStorage) 
        {
            List<Book> books = BookList.Select(pair => pair.Value).ToList();

            bookStorage.AddBooks(books);
        }
    }
}
