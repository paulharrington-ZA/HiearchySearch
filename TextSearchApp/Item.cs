using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextSearchApp
{
    internal static class StringExtensions
    {
        internal static bool IsMatch(this string s, string o, bool matchCase)
        {
            var regex = matchCase ? new Regex(o) : new Regex(o, RegexOptions.IgnoreCase);

            return regex.IsMatch(s);
        }

        internal static bool IsFullMatch(this string s, List<string> o, bool matchCase)
        {
            return o.Aggregate(true, (current, i) => current & s.IsMatch(i, matchCase));
        }
    }
}
