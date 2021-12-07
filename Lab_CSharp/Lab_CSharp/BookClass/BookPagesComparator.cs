namespace Lab_CSharp.BookClass
{
    /// <summary>Book Pages Comparator</summary>
    public class BookPagesComparator
    {
        /// <summary>Compare two books by pages</summary>
        /// <returns>int</returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            return firstBook.Pages.CompareTo(secondBook.Pages);
        }
    }
}