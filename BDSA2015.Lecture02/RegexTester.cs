using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BDSA2015.Lecture02
{
    public static class RegexTester
    {
        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }

        public static IList<string> Matches(string input, Regex expression)
        {
            var list = new List<string>();

            foreach (Match match in expression.Matches(input))
            {
                list.Add(match.Value);
            }

            return list;
        }

        public static IList<string> Groups(string input, string pattern)
        {
            var list = new List<string>();

            var match = Regex.Match(input, pattern);

            if (match.Success)
            {
                for (var i = 1; i < match.Groups.Count; i++)
                {
                    list.Add(match.Groups[i].Value);
                }
            }

            return list;
        }
    }
}
