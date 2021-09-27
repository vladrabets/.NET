using System;
using System.Globalization;

namespace VerificationService
{
    /// <summary>
    /// Class for validating currency strings.
    /// </summary>
    public static class IsoCurrencyValidator
    {
        /// <summary>
        /// Determines whether a specified string is a valid ISO currency symbol.
        /// </summary>
        /// <param name="currency">Currency string to check.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="currency"/> is a valid ISO currency symbol; <see langword="false"/> otherwise.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if currency is null or empty or whitespace or white-space.</exception>
        public static bool IsValid(string currency)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo ci in cultures)
            {

                RegionInfo ri = new RegionInfo(ci.LCID);

                if (ri.ISOCurrencySymbol == currency)

                {
                    return true;
                }

            }
            throw new ArgumentException();
        }
    }
}
