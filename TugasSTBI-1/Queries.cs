using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Queries
    {
        public string [] query;

        public Queries()
        {
            query = new string[1];
        }
        public Queries(string pathQueries)
        {
            // read file
            //temp = System.IO.File.ReadAllText(@pathQueries);
            string textQueries = System.IO.File.ReadAllText(@pathQueries);

            // split per query
            query = textQueries.Split(new string[] { ".I " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < query.Length; i++)
            {
                if (query[i].Contains("\n.B\n")) //untuk menangani test case cisi
                {
                    query[i] = Between(query[i], ".W\n", "\n.B");
                }
                else
                {
                    query[i] = After(query[i], ".W\n");
                }
                Console.WriteLine(query[i]);
            }
        }
        public string getQuery(int n)
        {
            return query[n];
        }
        public int nQuery()
        {
            return query.Count();
        }
        public void print()
        {
            Console.Write(nQuery());
            for (int i = 0; i < query.Length; i++ )
            {
                Console.Write(query[i]);
            }
                

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
    }
}
