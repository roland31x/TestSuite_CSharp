using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class Utils
{
    public static void Greet(string name){
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Hello, World!");
        }
        else
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }

    // 1. Check if string is palindrome
    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;
        s = s.ToLower();
        return s.SequenceEqual(s.Reverse());
    }

    // 2. Reverse string
    public static string ReverseString(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return new string(s.Reverse().ToArray());
    }

    // 3. Count vowels in string
    public static int CountVowels(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0;
        return s.Count(c => "aeiouAEIOU".Contains(c));
    }

    // 4. Capitalize first letter of each word
    public static string ToTitleCase(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
    }

    // 5. Remove whitespace from string
    public static string RemoveWhitespace(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return Regex.Replace(s, @"\s+", "");
    }

    // 6. Check if array contains duplicates
    public static bool HasDuplicates<T>(T[] arr)
    {
        if (arr == null) return false;
        return arr.Length != arr.Distinct().Count();
    }

    // 7. Flatten a 2D array to 1D
    public static T[] Flatten<T>(T[][] arr)
    {
        if (arr == null) return new T[0];
        return arr.SelectMany(x => x).ToArray();
    }

    // 8. Find max value in array
    public static T Max<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is empty or null.");
        return arr.Max();
    }

    // 9. Find min value in array
    public static T Min<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is empty or null.");
        return arr.Min();
    }

    // 10. Calculate average of int array
    public static double Average(int[] arr)
    {
        if (arr == null || arr.Length == 0) return 0;
        return arr.Average();
    }

    // 11. Remove null or empty strings from array
    public static string[] RemoveEmpty(string[] arr)
    {
        if (arr == null) return new string[0];
        return arr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }

    // 12. Repeat string N times
    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0) return "";
        return string.Concat(Enumerable.Repeat(s, n));
    }

    // 13. Check if string contains only digits
    public static bool IsNumeric(string s)
    {
        return !string.IsNullOrEmpty(s) && s.All(char.IsDigit);
    }

    // 14. Convert string to snake_case
    public static string ToSnakeCase(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsUpper(s[i]))
            {
                if (i > 0) sb.Append('_');
                sb.Append(char.ToLower(s[i]));
            }
            else
            {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }

    // 15. Generate random integer between min and max (inclusive)
    private static readonly Random rnd = new Random();
    public static int RandomInt(int min, int max)
    {
        return rnd.Next(min, max + 1);
    }

    // 16. Shuffle an array in place (Fisher-Yates)
    public static void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    // 17. Remove duplicates from array
    public static T[] Distinct<T>(T[] arr)
    {
        if (arr == null) return new T[0];
        return arr.Distinct().ToArray();
    }

    // 18. Find index of max element
    public static int IndexOfMax<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null || arr.Length == 0) return -1;
        int maxIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(arr[maxIndex]) > 0)
                maxIndex = i;
        }
        return maxIndex;
    }

    // 19. Find index of min element
    public static int IndexOfMin<T>(T[] arr) where T : IComparable<T>
    {
        if (arr == null || arr.Length == 0) return -1;
        int minIndex = 0;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(arr[minIndex]) < 0)
                minIndex = i;
        }
        return minIndex;
    }

    // 20. Convert list to comma separated string
    public static string ToCsv<T>(IEnumerable<T> list)
    {
        return list == null ? "" : string.Join(",", list);
    }

    // 21. Parse CSV string to list
    public static List<string> FromCsv(string csv)
    {
        if (string.IsNullOrEmpty(csv)) return new List<string>();
        return csv.Split(',').Select(s => s.Trim()).ToList();
    }

    // 22. Remove duplicates from List
    public static List<T> DistinctList<T>(List<T> list)
    {
        return list == null ? new List<T>() : list.Distinct().ToList();
    }

    // 23. Reverse a list
    public static List<T> ReverseList<T>(List<T> list)
    {
        if (list == null) return new List<T>();
        var reversed = new List<T>(list);
        reversed.Reverse();
        return reversed;
    }

    // 24. Get last element of array or default
    public static T LastOrDefault<T>(T[] arr)
    {
        if (arr == null || arr.Length == 0) return default;
        return arr[arr.Length - 1];
    }

    // 25. Join strings with a delimiter
    public static string JoinStrings(IEnumerable<string> strings, string delimiter)
    {
        return strings == null ? "" : string.Join(delimiter, strings);
    }

    // 26. Check if string is null or whitespace
    public static bool IsNullOrWhiteSpace(string s)
    {
        return string.IsNullOrWhiteSpace(s);
    }

    // 27. Count words in string
    public static int WordCount(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return 0;
        return Regex.Matches(s, @"\b\w+\b").Count;
    }

    // 28. Convert seconds to hh:mm:ss format
    public static string SecondsToTime(int seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);
        return t.ToString(@"hh\:mm\:ss");
    }

    // 29. Generate GUID string
    public static string GenerateGuid()
    {
        return Guid.NewGuid().ToString();
    }

    // 30. Check if string contains only letters
    public static bool IsAlpha(string s)
    {
        return !string.IsNullOrEmpty(s) && s.All(char.IsLetter);
    }

    // 31. Replace multiple spaces with single space
    public static string NormalizeSpaces(string s)
    {
        return Regex.Replace(s, @"\s+", " ").Trim();
    }

    // 32. Remove all digits from string
    public static string RemoveDigits(string s)
    {
        return Regex.Replace(s ?? "", @"\d", "");
    }

    // 33. Get substring between two markers
    public static string SubstringBetween(string s, string start, string end)
    {
        if (string.IsNullOrEmpty(s)) return "";
        int startIndex = s.IndexOf(start);
        if (startIndex == -1) return "";
        startIndex += start.Length;
        int endIndex = s.IndexOf(end, startIndex);
        if (endIndex == -1) return "";
        return s.Substring(startIndex, endIndex - startIndex);
    }

    // 34. Check if array contains a value
    public static bool Contains<T>(T[] arr, T value)
    {
        return arr != null && arr.Contains(value);
    }

    // 35. Convert array to list
    public static List<T> ToList<T>(T[] arr)
    {
        return arr == null ? new List<T>() : arr.ToList();
    }

    // 36. Capitalize first letter of string
    public static string Capitalize(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return char.ToUpper(s[0]) + s.Substring(1);
    }

    // 37. Check if string ends with any of given suffixes
    public static bool EndsWithAny(string s, params string[] suffixes)
    {
        if (s == null || suffixes == null) return false;
        return suffixes.Any(suffix => s.EndsWith(suffix));
    }

    // 38. Remove punctuation from string
    public static string RemovePunctuation(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return Regex.Replace(s, @"[^\w\s]", "");
    }

    // 39. Convert string to kebab-case
    public static string ToKebabCase(string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        var sb = new StringBuilder();
        foreach (char c in s)
        {
            if (char.IsUpper(c))
            {
                if (sb.Length > 0) sb.Append('-');
                sb.Append(char.ToLower(c));
            }
            else if (c == ' ' || c == '_')
            {
                sb.Append('-');
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }

    // 40. Calculate factorial (recursive)
    public static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("Negative number");
        if (n == 0 || n == 1) return 1;
        return n * Factorial(n - 1);
    }

    // 41. Check if number is prime
    public static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;
        for (int i = 5; i * i <= n; i += 6)
        {
            if (n % i == 0 || n % (i + 2) == 0) return false;
        }
        return true;
    }

}