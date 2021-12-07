using System;

namespace Lab_CSharp.BookClass
{
    /// <summary>Book Author Comparator</summary>
    public class BookAuthorComparator
    {
        /// <summary>Compare two books by author</summary>
        /// <returns>int</returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            return String.Compare(firstBook.Author, secondBook.Author, StringComparison.Ordinal);
        }
    }
}