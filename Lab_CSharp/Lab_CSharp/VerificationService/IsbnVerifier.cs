using System;
using System.Text.RegularExpressions;

namespace Lab_CSharp.VerificationService
{
    /// <summary>
    /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
    /// </summary>
    public static class IsbnVerifier
    {
        /// <summary>
        /// Verifies if the string representation of number is a valid ISBN-10 or ISBN-13 identification number of book.
        /// </summary>
        /// <param name="isbn">The string representation of book's isbn.</param>
        /// <returns>true if number is a valid ISBN-10 or ISBN-13 identification number of book, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown if isbn is null.</exception>
        public static bool IsValid(string isbn)
        {
            switch (isbn.Length)
            {
                case 0: return true;
                case 13: return IsValidIsbn10(isbn);
                case 17: return IsValidIsbn13(isbn);
            }
            return false;
        }
        
        /// <summary>
        /// ISBN10
        /// </summary>
        /// <param name="isbn10">code to validate</param>
        /// <returns>true if valid</returns>
        private static bool IsValidIsbn10(string isbn10)
        {
            if (!string.IsNullOrEmpty(isbn10))
            {
                long j = 0;
                if (isbn10.Contains('-'))
                {
                    isbn10 = isbn10.Replace("-", "");
                }

                if (!Int64.TryParse(isbn10[..^1], out j))
                {
                    return false;
                }

                char lastChar = isbn10[^1];
                if (lastChar == 'X' && !Int64.TryParse(lastChar.ToString(), out j))
                {
                    return false;
                }
                
                int checkSum = 0;
                for (int i = 0; i < 9; i++)
                {
                    checkSum += Int32.Parse(isbn10[i].ToString()) * (i + 1);
                }

                int remainder = checkSum % 11;

                return (remainder == int.Parse(isbn10[9].ToString()));
            }

            return false;
        }
        
        /// <summary>
        /// ISBN13
        /// </summary>
        /// <param name="isbn13">code to validate></param>
        /// <returns>true, if valid</returns>
        private static bool IsValidIsbn13(string isbn13)
        {
            if (!string.IsNullOrEmpty(isbn13))
            {
                long j = 0;
                if (isbn13.Contains('-'))
                {
                    isbn13 = isbn13.Replace("-", "");
                }

                if (!Int64.TryParse(isbn13, out j))
                {
                    return false;
                }

                int checkSum = 0;

                for (int i = 0; i < 12; i++)
                {
                    checkSum += Int32.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                int remainder = checkSum % 10;
                int checkDigit = 10 - remainder;
                if (checkDigit == 10)
                {
                    checkDigit = 0;
                }
                return (checkDigit == int.Parse(isbn13[12].ToString()));
            }
            return false;
        }

    }
}
