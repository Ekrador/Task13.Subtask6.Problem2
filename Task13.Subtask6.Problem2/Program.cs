using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13.Subtask6.Problem2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] path = { @"C:\Users", Environment.UserName, "Desktop", "Text.txt" };
            string fullPath = Path.Combine(path);
            string text = File.ReadAllText(fullPath);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 1);
                }
                dictionary[word] += 1;
            }

            var list = dictionary.OrderByDescending(key => key.Value).ToList().GetRange(0,9);
            foreach (KeyValuePair<string, int> word in list)
            {
                Console.WriteLine("Слово \"{0}\" встречается {1} раз", word.Key, word.Value);
            }

            Console.ReadLine();
        }
    }
}
