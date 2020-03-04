using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter search items, <press enter for defaults>, Seperate with semicolon");
            var userItems = Console.ReadLine();
            var items = userItems?.Split(';').ToList() ?? new List<string> { "Users", "User Groups", "User Activity Log" };
            Console.WriteLine("Match case? (y/n)");
            var input = Console.ReadLine();
            var matchCase = input?.ToUpperInvariant() == "Y" || input?.ToUpperInvariant() == "YES";
            Console.WriteLine("Items in list are:\r\n");
            items.ForEach(i => Console.Write(i + ", "));
            Console.WriteLine("Enter Search String <Press Enter to Continue>:");
            var s = Console.ReadLine();
            if (s != null)
            {
                var sS = s.Split(' ').ToList();
                var matches = items.Where(i => i.IsFullMatch(sS, matchCase));
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("Invalid input terminating program");
            }

            Console.ReadKey();
        }
    }
}
