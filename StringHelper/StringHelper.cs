using System.Globalization;
using System.Text.RegularExpressions;

namespace StringHelper
{
    /// <summary>
    /// Global class providing String methods.
    /// </summary>
    public static class StringHelper
    {
        private static bool IsNegativeNumber(int value) =>
            value < 0;

        private static bool IsZero(int value) =>
            value == 0;

        /// <summary>
        /// Returns the string with each word capitalised.
        /// </summary>
        /// <param name="text">Value to convert</param>
        public static string GetCapitaliseEachWord(string value)
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
        /// Returns the value with the tabs, new line characters and extra spaces removed.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string GetCleanString(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            return RemoveExtraSpaces(
                value.Replace("\n", "")
                    .Replace("\t", ""));
        }

        /// <summary>
        /// Returns the specific number of characters from the left of the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="length">Length of the string to return</param>
        public static string GetLeft(string value, int length)
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
        /// Returns all the characters starting from a certain point.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="start">Start point of the string to return</param>
        public static string GetMid(string value, int start)
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
        public static string GetMid(string value, int start, int length)
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
        /// Returns the specific number of characters from the right of the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="length">Length of the string to return</param>
        public static string GetRight(string value, int length)
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
        /// Returns the number of characters in the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="cleanString">Clean string</param>
        public static int GetTotalNumberOfCharacters(string value, bool cleanString = false)
        {
            if (String.IsNullOrEmpty(value))
                return 0;

            return cleanString
                ? GetCleanString(value).Length
                : value.Length;
        }

        /// <summary>
        /// Returns the number of words in the string.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static int GetTotalNumberOfWords(string value)
        {
            if (String.IsNullOrEmpty(value))
                return 0;

            return value.Split(
                new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Returns the times the search string appears
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="serach">Search string</param>
        public static int GetStringCount(string value, string search)
        {
            if (String.IsNullOrWhiteSpace(value))
                return 0;

            return value.Split(search)
                .Length - 1;
        }

        /// <summary>
        /// Returns the value with extra spaces removed from the value.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string RemoveExtraSpaces(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            string pattern = "\\s+";
            string replacement = " ";

            var regex = new Regex(pattern);
            return regex.Replace(value, replacement).Trim();
        }

        /// <summary>
        /// Returns the value with all double quotes replaced with single quotes.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string ReplaceDoubleQuotesWithSingle(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            return value.Replace("\"", "'");
        }

        /// <summary>
        /// Returns the value with all single quotes replaced with double quotes.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string ReplaceSingleQuotesWithDouble(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            return value.Replace("'", "\"");
        }

        /// <summary>
        /// Returns the value with new lines replaced with spaces.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string ReplaceNewLinesWithSpaces(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            return RemoveExtraSpaces(value.Replace("\n", " "));
        }

        /// <summary>
        /// Returns the value with tabs replaced with spaces.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string ReplaceTabsWithSpaces(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            return RemoveExtraSpaces(value.Replace("\t", " "));
        }

        /// <summary>
        /// Returns the value reversed.
        /// </summary>
        /// <param name="value">Value to convert</param>
        public static string Reverse(string value)
        {
            if (String.IsNullOrEmpty(value))
                return value;

            var chars = value.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }
}
                                         