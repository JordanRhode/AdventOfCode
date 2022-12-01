namespace AdventOfCode.Solutions.Utils;

public static class StringUtils
{
    public static readonly string[] NewLineDelimiter = new[] { "\r", "\n", "\r\n" };
    public static readonly string[] ParagraphDelimiter = new[] { "\r\r", "\n\n", "\r\n\r\n" };
    public static string Reverse(this string str)
    {
        char[] arr = str.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    public static string[] SplitByNewline(this string str, bool shouldTrim = false, StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries) => str
        .Split(NewLineDelimiter, splitOptions)
        .Select(s => shouldTrim ? s.Trim() : s)
        .ToArray();

    public static string[] SplitByParagraph(this string str, bool shouldTrim = false, StringSplitOptions splitOptions = StringSplitOptions.RemoveEmptyEntries) => str
        .Split(ParagraphDelimiter, splitOptions)
        .Select(s => shouldTrim ? s.Trim() : s)
        .ToArray();

    public static int[] ToIntArray(this string str, string[] delimiter)
    {
        if (delimiter is null || delimiter.Length == 0)
        {
            var result = new List<int>();
            foreach (char c in str) if (int.TryParse(c.ToString(), out int n)) result.Add(n);
            return result.ToArray();
        }
        else
        {
            return str
                .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }

    public static long[] ToLongArray(this string str, string[]? delimiter)
    {
        if (delimiter is null || delimiter.Length == 0)
        {
            var result = new List<long>();
            foreach (char c in str) if (long.TryParse(c.ToString(), out long n)) result.Add(n);
            return result.ToArray();
        }
        else
        {
            return str
                .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
        }
    }
}
