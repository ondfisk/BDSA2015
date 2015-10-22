using System;
using System.Text.RegularExpressions;

namespace BDSA2015.Lecture02.Bonus
{
    public class RegularExpressions
    {
        public void Groups()
        {
            string text = @"http://www.test.com ftp://ftp.test.com";
                                                            // ?: = Non-capturing group
            MatchCollection matches = Regex.Matches(text, @"\b(?:\S+)://(\S+)\b");

            foreach (Match match in matches)
            {
                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("{0}: {1}", match.Index, group);
                }
            }
        }
    }
}
