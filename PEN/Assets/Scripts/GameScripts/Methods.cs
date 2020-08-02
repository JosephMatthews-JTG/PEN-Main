using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using static BreakInfinity.BigDouble;

public class Methods : MonoBehaviour
{
    public static string NotationMethod(double x, string y)
    {
        if (x >= 1000000)
        {
            var exponent = Math.Floor(Math.Log10(Math.Abs(x)));
            var mantissa = x / Math.Pow(10, exponent);
            return $"{mantissa:F2}e{exponent:F0}";
        }
        return x.ToString(y);
    }

    public static string NotationMethodBD(BigDouble x, string y)
    {
        if (x >= 1000000)
        {
            var exponent = Floor(Log10(Abs(x)));
            var mantissa = x / Pow(10, exponent);
            return $"{mantissa:F2}e{exponent:F0}";
        }
        return x.ToString(y);
    }
}
