using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UC1EmployeePayrollSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] words = CreateWordArray(@"https://www.gutenberg.org/files/54700/54700-0.txt");
            #region ParallelTasks
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Begin first task...");
                GetLongestWord(words);
            },
            () =>
            {
                Console.WriteLine("Begin Second task...");
                GetMostCommonWords(words);
            }, //close second Action
            () =>
            {
                Console.WriteLine("Begin third task...");
                GetCountForWord(words, "sleep");
            } //close third Action

            ); //close parallel.invoke
            #endregion
        }

        private static void GetCountForWord(string[] words, string term)
        {
            var findWord = from word in words
                           where word.ToUpper().Contains(term.ToUpper())
                           select word;
            Console.WriteLine($0"Task 3 - The Word ""{ term}""occurs{findWord.Count()} times.");
        }

        private static void GetMostCommonWords(string[] words)
        {
            var frequencyOrder = from word in words
                                 where word.Length > 6
                                 group word by word into g
                                 orderby g.count() descending
                                 select g.key;
            var commonWords = frequencyOrder.Take(10);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Task 2 - The most common words are:");
            foreach (var v in commonWords)
            {
                sb.AppendLine(" " + v);
            }
            Console.WriteLine(sb.ToString());
        }

        private static string GetLongestWord(string[] words)
        {
            var longestWord = (from w in words
                               orderby w.Length descending
                               select w).First();
            Console.WriteLine($"Task 1 - The longest word is {longestWord}.");
            return longestWord;
        }
        static string[] CreateWordArray(string uri)
        {
            Console.WriteLine($"Retrieving from {uri}");
            //Download a web page the easy way.
            string blog = new WebClient().DownloadString(uri);

            //Separate string into an array of words, reciving sort comman numctuation
            return blog.Split(
            new char[] { ' ', '\u000A', ',', '.', ':', ';', '-', '_', '/' },
            StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
