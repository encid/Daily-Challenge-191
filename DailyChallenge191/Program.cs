using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CountWords("H:\\birds.txt");
        }

        static void CountWords(string path)
        {
            var wordList = new Dictionary<string, int>();
            string txt;
            using (StreamReader sr = new StreamReader(path)) {
                txt = sr.ReadToEnd();
            }

            var words = txt.Split(' ');

            foreach (string word in words) {
                if (!wordList.ContainsKey(word.ToLower())) {
                    wordList.Add(word.ToLower(), 1);
                }
                if (wordList.ContainsKey(word.ToLower())) {
                    wordList[word.ToLower()] += 1;
                }
            }

            var items = from pair in wordList
                    orderby pair.Value descending
                    select pair;

            foreach (var w in items) {
                Console.WriteLine("{0}: {1}", w.Key, w.Value);
            }

            Console.ReadKey();
            
        }
    }
}
