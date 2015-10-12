using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    /// <summary>
    /// Reference: http://www.dotnetperls.com/stopword-dictionary 
    /// </summary>
    class StopwordTool
    {
        /// <summary>
        /// Words we want to remove.
        /// </summary>
        static Dictionary<string, bool> _stops = new Dictionary<string, bool>();

        /// <summary>
        /// Chars that separate words.
        /// </summary>
        static char[] _delimiters = new char[]
        {
	        ' ',
	        ',',
	        ';',
	        '.',
            '-',
            '\n',
            '\'',
            ':',
            '(',
            ')',
            '/'
        };

        public static void AddDictionaryFromText(string location)
        {
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(location))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line); // Add to list.
                }
            }
            foreach (string word in words)
            {
                _stops.Add(word, true);
            }
        }

        /// <summary>
        /// Remove stopwords from string.
        /// </summary>
        public static string RemoveStopwords(string input)
        {
            // 1
            // Split parameter into words
            var words = input.Split(_delimiters,
                StringSplitOptions.RemoveEmptyEntries);
            // 2
            // Allocate new dictionary to store found words
            //var found = new Dictionary<string, bool>();
            // 3
            // Store results in this StringBuilder
            StringBuilder builder = new StringBuilder();
            // 4
            // Loop through all words
            foreach (string currentWord in words)
            {
                // 5
                // Convert to lowercase
                string lowerWord = currentWord.ToLower();
                // 6
                // If this is a usable word, add it
                if (!_stops.ContainsKey(lowerWord) 
                    //&& !found.ContainsKey(lowerWord)
                    )
                {
                    builder.Append(currentWord).Append(' ');
                    //found.Add(lowerWord, true);
                }
            }
            // 7
            // Return string with words removed
            return builder.ToString().Trim();
        }
    }
}
