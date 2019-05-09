using static System.Environment;

namespace System
{    
    internal static class StringExtension
    {
        internal static string RemoveLastNewLine(this string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var endingIndex = source.Length - NewLine.Length;
            var result = source.Substring(0, endingIndex);
            return result;
        }
    }
}
