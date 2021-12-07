using System.Collections.Generic;

namespace Lab_CSharp.BookClass
{
    /// <summary>Book Price Comparator</summary>
    public class BookPriceComparator:IComparer<Book>
    {
        /// <summary>Compare two books by price</summary>
        /// <returns>int</returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            switch (firstBook)
            {
                case null when secondBook == null:
                    return 0;
                case null:
                    return -1;
            }

            if (secondBook == null)
            {
                return 1;
            }

            return firstBook.Price.CompareTo(secondBook.Price);
        }
    }
}
