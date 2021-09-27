using System;
using NUnit.Framework;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable SA1600 // Elements should be documented

namespace BookClass.Tests
{
    [TestFixture]
    public class BookTests
    {
        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications")]
        public void Book_CreateNewThreeParameters(string author, string title, string publisher)
        {
            Book book = new Book(author, title, publisher); 
            Assert.IsTrue(book.Author == author && book.Title == title && book.Publisher == publisher); 
        }

        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications", "978-0-901-69066-1")]
        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications", "3-598-21508-8")]
        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications", "")]
        public void Book_CreateNewFourParameters(string author, string title, string publisher, string isbn)
        {
            Book book = new Book(author, title, publisher, isbn);
            Assert.IsTrue(book.Author == author && book.Title == title && book.Publisher == publisher && book.ISBN == isbn);
        }

        [TestCase(null, "C# in Depth", "Manning Publications")]
        [TestCase("Jon Skeet", null, "Manning Publications")]
        [TestCase("Jon Skeet", "C# in Depth", null)]
        public void Book_CreateNewThreeParameters_ThrowArgumentNullException(string author, string title, string publisher)
        {
            Assert.Throws<ArgumentNullException>(() => new Book(author, title, publisher), "author or title or publisher cannot be null");
        }

        [TestCase(null, "C# in Depth", "Manning Publications", "978-0-901-69066-1")]
        [TestCase("Jon Skeet", null, "Manning Publications", "978-0-901-69066-1")]
        [TestCase("Jon Skeet", "C# in Depth", null, "978-0-901-69066-1")]
        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications", null)]
        public void Book_CreateNewFourParameters_ThrowArgumentNullException(string author, string title, string publisher, string isbn)
        {
            Assert.Throws<ArgumentNullException>(() => new Book(author, title, publisher, isbn), "author or title or publisher or ISBN cannot be null");
        }

        [Test]
        public void Book_PagesTest()
        {
            int expected = 10;
            Book book = new Book(string.Empty, string.Empty, string.Empty)
            {
                Pages = expected,
            };
            Assert.AreEqual(expected, book.Pages);
        }

        [TestCase(-1)]
        [TestCase(0)]
        public void Book_PagesTest_ArgumentOutOfRangeException(int pages)
        {
            Book book = new Book(string.Empty, string.Empty, string.Empty);
            Assert.Throws<ArgumentOutOfRangeException>(() => book.Pages = pages, "Count of pages should be greater than zero.");
        }

        [Test]
        public void Book_Publish_GetPublicationDate_Tests()
        {
            DateTime expected = DateTime.Now;
            Book book = new Book(string.Empty, string.Empty, string.Empty);
            book.Publish(expected);

            Assert.AreEqual(FormattableString.Invariant($"{expected:d}"), book.GetPublicationDate());
        }

        [Test]
        public void Book_Publish_GetPublicationDate_Empty_Tests()
        {
            string expected = "NYP";
            Book book = new Book(string.Empty, string.Empty, string.Empty);
            Assert.AreEqual(expected, book.GetPublicationDate());
        }

        [Test]
        public void Book_SetPrice_Tests()
        {
            decimal price = 4.44m;
            string currency = "USD";
            Book book = new Book(string.Empty, string.Empty, string.Empty);
            book.SetPrice(price, currency);
            Assert.IsTrue(book.Price == price && book.Currency == currency);
        }

        [Test]
        public void Book_SetPrice_InvalidCurrency_ArgumentException()
        {
            decimal price = 4.44m;
            string currency = "_~_";
            Book book = new Book(string.Empty, string.Empty, string.Empty);

            Assert.Throws<ArgumentException>(() => book.SetPrice(price, currency), "Currency is invalid.");
        }

        [Test]
        public void Book_SetPrice_LessZero_ArgumentException()
        {
            decimal price = -4.44m;
            string currency = "USD";
            Book book = new Book(string.Empty, string.Empty, string.Empty);

            Assert.Throws<ArgumentException>(() => book.SetPrice(price, currency), "Price cannot be less than zero.");
        }

        [Test]
        public void Book_SetPrice_CurrencyIsNull_ArgumentNullException()
        {
            decimal price = 4.44m;
            Book book = new Book(string.Empty, string.Empty, string.Empty);

            Assert.Throws<ArgumentNullException>(() => book.SetPrice(price, null), "Currency cannot be null.");
        }

        [TestCase("Jon Skeet", "C# in Depth", "Manning Publications", ExpectedResult = "C# in Depth by Jon Skeet")]
        [TestCase("Jon Skeet", "", "Manning Publications", ExpectedResult = " by Jon Skeet")]
        [TestCase("", "C# in Depth", "Manning Publications", ExpectedResult = "C# in Depth by ")]
        public string Book_ToString(string author, string title, string publisher)
            => new Book(author, title, publisher).ToString();
        
        //my tests
        
        [Test]
        public void Book_Publish_Test()
        {
            const int year = 2011;
            const int month = 11;
            const int day = 11;
            DateTime date = new DateTime(year, month, day);

            Book book = new Book("Author", "Title", "Publisher");
            book.Publish(date);
            Assert.AreEqual(book.GetPublicationDate(), $"{month}/{day}/{year}");
        }

        [Test]
        public void Book_Publish_NotPublished_Test()
        {
            Book book = new Book("Author", "Title", "Publisher");
            Assert.AreEqual(book.GetPublicationDate(), "NYP");
        }
    }
}