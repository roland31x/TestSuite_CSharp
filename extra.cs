using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class Extra
{
    public static bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
            if (num % i == 0) return false;
        return true;
    }

    public static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static int Lcm(int a, int b)
    {
        return a * (b / Gcd(a, b));
    }

    public static Dictionary<string, object> FlattenDict(Dictionary<string, object> dict, string prefix = "")
    {
        var result = new Dictionary<string, object>();
        foreach(var kvp in dict)
        {
            string key = prefix == "" ? kvp.Key : prefix + "." + kvp.Key;
            if (kvp.Value is Dictionary<string, object> nested)
            {
                foreach(var inner in FlattenDict(nested, key))
                    result.Add(inner.Key, inner.Value);
            }
            else
            {
                result[key] = kvp.Value;
            }
        }
        return result;
    }

    public static T MostCommon<T>(List<T> list)
    {
        return list.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;
    }

    public static List<List<T>> Transpose<T>(List<List<T>> matrix)
    {
        var result = new List<List<T>>();
        int rows = matrix.Count;
        if (rows == 0) return result;
        int cols = matrix[0].Count;
        for(int i=0; i < cols; i++)
        {
            var col = new List<T>();
            for(int j=0; j < rows; j++)
                col.Add(matrix[j][i]);
            result.Add(col);
        }
        return result;
    }

    public static string CamelToSnake(string str)
    {
        return Regex.Replace(str, "([A-Z])", "_$1").ToLower();
    }

    public static string SwapCase(string s)
    {
        return new string(s.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)).ToArray());
    }

    public static int NestedSum(IEnumerable<object> list)
    {
        int sum = 0;
        foreach(var item in list)
        {
            if (item is IEnumerable<object> innerList)
                sum += NestedSum(innerList);
            else if(item is int n)
                sum += n;
        }
        return sum;
    }

    public static int DigitSum(int num)
    {
        return Math.Abs(num).ToString().Sum(c => c - '0');
    }
}