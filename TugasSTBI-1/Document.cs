using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Document
    {
        public string No { get; set; }
        public string Title { get; set; }
        public string [] Author { get; set; }
        public string [] Content { get; set; }

        public Document(string text)
        {
            No = Before(text, "\n.T");
            Title = Between(text, ".T\n", "\n.A");
            
            string TextAuthor = Between(text, ".A\n", "\n.W");
            if(TextAuthor.Contains("\n"))   // if author more than one
            {
                // Split text per author
                Author = TextAuthor.Split('\n');
            }
            else                            // if author just one
            {
                Author = new string[1];
                Author[0] = TextAuthor;
            }

            string ContentString = StopwordTool.RemoveStopwords(After(text, ".W\n"));

            // Regex, untuk menghilangkan angka
            ContentString = Regex.Replace(ContentString, @"[0-9]+ ", string.Empty);

            // Stemming, mengubah kata ke bentuk dasarnya
            StemmingTool Stemmer = new StemmingTool();
            ContentString = Stemmer.Stemming(ContentString);

            // Split Content per word
            Content = ContentString.Split(' ');
        }

        /// <summary>
        /// Reference: http://www.dotnetperls.com/between-before-after
        /// get document Author and Title
        /// </summary>
        private string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }

        /// <summary>
        /// Reference: http://www.dotnetperls.com/between-before-after
        /// get document number 
        /// </summary>
        private string Before(string value, string a)
        {
            int posA = value.IndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            return value.Substring(0, posA);
        }

        /// <summary>
        /// Reference: http://www.dotnetperls.com/between-before-after
        /// get document content 
        /// </summary>
        private string After(string value, string a)
        {
            int posA = value.LastIndexOf(a);
            if (posA == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= value.Length)
            {
                return "";
            }
            return value.Substring(adjustedPosA);
        }
    }
}
