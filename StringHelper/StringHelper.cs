using System.Globalization;

namespace StringHelper
{
    /// <summary>
    /// Global class providing String methods.
    /// </summary>
    public static class StringHelper
    {
        public static bool IsNegativeNumber(int value) =>
            value < 0;

        public static bool IsZero(int value) =>
            value == 0;

        /// <summary>
        /// Returns the string with each word capitalised.
        /// </summary>
        /// <param name="text">Value to convert</param>
        public static string CapitaliseEachWord(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (IsNegativeNumber(value.Length))
                return value;

            return CultureInfo
                .CurrentCulture
                .TextInfo
                .ToTitleCase(value.ToLower());
        }

        /// <summary>
        /// Returns the specific number of characters from the left of the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="length">Length of the string to return</param>
        public static string Left(string value, int length)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (IsNegativeNumber(length))
                throw new ArgumentOutOfRangeException(nameof(length));

            return value.Substring(
                0,
                Math.Min(value.Length, length));
        }

        /// <summary>
        /// Returns the specific number of characters from the right of the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="length">Length of the string to return</param>
        public static string Right(string value, int length)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (IsNegativeNumber(length))
                throw new ArgumentOutOfRangeException(nameof(length));

            return value.Substring(
                Math.Max(value.Length - length, 0),
                Math.Min(length, value.Length));
        }

        /// <summary>
        /// Returns all the characters starting from a certain point.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="start">Start point of the string to return</param>
        public static string Mid(string value, int start)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (IsZero(start))
                return "";

            if (IsNegativeNumber(start))
                throw new ArgumentOutOfRangeException(nameof(start));

            return value.Substring(
                Math.Min(start, value.Length));
        }

        /// <summary>
        /// Returns all the characters starting from a certain point.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="start">Start point of the string to return</param>
        /// <param name="length">Length of the string to return</param>
        public static string Mid(string value, int start, int length)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            if (IsZero(length))
                return "";

            if (IsNegativeNumber(start)
                || IsNegativeNumber(length))
                throw new ArgumentOutOfRangeException(nameof(length));

            return value.Substring(
                Math.Min(start, value.Length),
                Math.Min(length, Math.Max(value.Length - start, 0)));
        }

        /// <summary>
        /// Returns the number of words in the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="defaultValue">Default value</param>
        public static int GetTotalNumberOfWords(string value)
        {
            if (String.IsNullOrEmpty(value))
                return 0;

            return value.Split(
                new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
