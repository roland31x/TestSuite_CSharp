using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Extra {

    public static string RandomString(int length = 10) {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var sb = new StringBuilder();
        for(int i = 0; i < length; i++) {
            sb.Append(chars[random.Next(chars.Length)]);
        }
        return sb.ToString();
    }

    public static long Factorial(int n) {
        if(n == 0) return 1;
        return n * Factorial(n - 1);
    }

    public static bool IsPalindrome(string s) {
        var str = new string(s.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
        return str.SequenceEqual(str.Reverse());
    }

    public static List<T> UniqueElements<T>(List<T> list) {
        return list.Distinct().ToList();
    }

    public static List<T> FlattenList<T>(List<List<T>> nestedList) {
        return nestedList.SelectMany(x => x).ToList();
    }

    public static long Fibonacci(int n) {
        long a = 0, b = 1;
        for(int i = 0; i < n; i++) {
            long temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    public static int CountVowels(string s) {
        return s.Count(c => "aeiouAEIOU".Contains(c));
    }

    public static Dictionary<TKey, TValue> MergeDictionaries<TKey, TValue>(params Dictionary<TKey, TValue>[] dicts) {
        var result = new Dictionary<TKey, TValue>();
        foreach(var dict in dicts) {
            foreach(var kvp in dict) {
                result[kvp.Key] = kvp.Value;
            }
        }
        return result;
    }

    public static string ReverseWords(string sentence) {
        var words = sentence.Split(' ');
        var reversedWords = words.Select(w => new string(w.Reverse().ToArray()));
        return string.Join(" ", reversedWords);
    }

    public static List<List<T>> ChunkList<T>(List<T> list, int chunkSize) {
        var chunks = new List<List<T>>();
        for(int i = 0; i < list.Count; i += chunkSize) {
            chunks.Add(list.GetRange(i, Math.Min(chunkSize, list.Count - i)));
        }
        return chunks;
    }
}