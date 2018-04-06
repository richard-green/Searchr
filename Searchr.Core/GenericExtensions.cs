using System.Collections.Generic;
using System.Linq;

public static class GenericExtensions
{
    /// <summary>
    /// Generic list searcher
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool InList<T>(this T input, IEnumerable<T> list) where T : System.IComparable<T>
    {
        return list.FirstOrDefault(where => where.CompareTo(input) == 0) != null;
    }

    /// <summary>
    /// Generic list searcher
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="input"></param>
    /// <param name="list"></param>
    /// <returns></returns>
    public static bool InList<T>(this T input, params T[] list) where T : System.IComparable<T>
    {
        return InList(input, list.AsEnumerable());
    }
}
