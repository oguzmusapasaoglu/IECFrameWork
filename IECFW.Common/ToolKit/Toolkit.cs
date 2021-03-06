using System;
using System.Collections.Generic;
using System.Linq;

public static class Toolkit
{
    public static int ToInt(this bool value)
    {
        return (value) ? 1 : 0;
    }
    public static int ToInt(this object value)
    {
        int ParmOut;
        return int.TryParse(value.ToString(), out ParmOut)
            ? ParmOut
            : 0;
    }
    public static long ToLong(this object value)
    {
        long ParmOut;
        return long.TryParse(value.ToString(), out ParmOut)
            ? ParmOut
            : 0;
    }
    public static bool IsNullOrEmpty(this object value)
    {
        return (value == null || value.ToString().Trim() == string.Empty);
    }
    public static bool IsNotNullOrEmpty(this object value)
    {
        return (value == null || value.ToString().Trim() == string.Empty) ? false : true;
    }
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return (value == null || value.Any());
    }
    public static bool IsNullOrLessOrEqToZero(this object value)
    {
        return (value == null || value.ToLong() <= 0);
    }

    #region Enum
    public static int ToInt<T>(this T value) where T : Enum
    {
        return (int)Enum.Parse(value.GetType(), value.ToString());
        //return Convert.ToInt32(value);
    }
    public static T ToEnum<T>(this object enumData) where T : Enum
    {
        return (T)Enum.Parse(typeof(T), enumData.ToString());
    } 
    #endregion
}