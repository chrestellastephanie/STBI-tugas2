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
        //public string [] Author { get; set; }
        public string [] Content { get; set; }

        public Document(string text, int stemCode)
        {
            No = "";
            Title = "";
            Content = new string[1];
            Content[0] = " ";
            text = "\n.I " + text;
            string[] textSplitedByPart = text.Split(new string[] { "\n." }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0 ; i<textSplitedByPart.Count(); i++)
            {
                //Console.WriteLine(textSplitedByPart[i]);
                //Console.WriteLine("-.-.-.-.-.-.-");

                if (textSplitedByPart[i][0]=='I')
                {
                    //Console.WriteLine("masuk sini");

                    string[] chunk = textSplitedByPart[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    No = chunk[1];
                    Console.WriteLine("no : " + No);
                }
                else if (textSplitedByPart[i][0] == 'T')
                {
                    if (textSplitedByPart[i].Length!=1)
                    {
                        Title = textSplitedByPart[i].Substring(2);
                    }
                    else
                    {
                        Title = " ";
                    }
                    //Console.WriteLine("title : " + Title);
                }
                //else if (textSplitedByPart[i][0]=='A')
                //{
                //    Console.WriteLine("masuk ke A");
                //    Author[0] = textSplitedByPart[i].Substring(2);
                //    Console.WriteLine("author : " + Author);
                //}
                else if (textSplitedByPart[i][0]=='W')
                {
                    string strContent = textSplitedByPart[i].Substring(2);
                    strContent = StopwordTool.RemoveStopwords(strContent);
                    Console.WriteLine(strContent);
                    //remove number from content text
                    strContent = Regex.Replace(strContent, @"[0-9]+ ", string.Empty);
                    if (stemCode == 1)
                    {
                        // Stemming, mengubah kata ke bentuk dasarnya
                        StemmingTool Stemmer2 = new StemmingTool();
                        strContent = Stemmer2.Stemming(strContent);
                    }
                    Content = strContent.Split(' ');
                    //print content
                    //Console.WriteLine("content : ");
                    //for (int j = 0; j < Content.Count(); j++)
                    //{
                    //    Console.Write(Content[j] + " ");
                    //}
                }
                else
                {
                    //Console.WriteLine("ga diambil");
                }
            }

            /*
            if(!text.Contains("\n.A"))  // if doesn't have author
            {
                No = Before(text, "\n.T");
                Title = Between(text, ".T\n", "\n.W");
                Author = null;
            }
            else
            {
                No = Before(text, "\n.T");
                Title = getTitleRecurrence(Between(text, ".T\n", "\n.A"));

                string TextAuthor = Between(text, ".A\n", "\n.W");
                if(TextAuthor.Contains("\n.A\n"))
                {
                    Author = TextAuthor.Split(new string[] { "\n.A\n" }, StringSplitOptions.None);
                }
                else
                {
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
                }
            }

            string ContentString;
            if(text.Contains("\n.X\n"))
            {
                ContentString = StopwordTool.RemoveStopwords(Between(text, ".W\n", "\n.X"));
            }
            else
            {
                ContentString = StopwordTool.RemoveStopwords(After(text, ".W\n"));
            }

            // Regex, untuk menghilangkan angka
            ContentString = Regex.Replace(ContentString, @"[0-9]+ ", string.Empty);

            if(stemCode == 1)
            {
                // Stemming, mengubah kata ke bentuk dasarnya
                StemmingTool Stemmer = new StemmingTool();
                ContentString = Stemmer.Stemming(ContentString);
            }

            // Split Content per word
            Content = ContentString.Split(' ');
             */
        }

        private string getTitleRecurrence(string text)
        {
            if (text.Contains("\n.A\n"))
            {
                return getTitleRecurrence(Before(text, "\n.A"));
            }
            else
            {
                return text;
            }
        }

        /// <summary>
        /// Reference: http://www.dotnetperls.com/between-before-after
        /// get document Author and Title
        /// </summary>
        public string Between(string value, string a, string b)
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
        public string Before(string value, string a)
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
        public string After(string value, string a)
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
