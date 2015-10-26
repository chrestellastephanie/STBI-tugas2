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
                query[i] = After(query[i], ".W\n");
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
    }
}
