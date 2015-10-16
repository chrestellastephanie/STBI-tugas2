using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Program
    {
        public static void weightQuery(string q/*, List<Document> ListDocuments*/)
        {
            float wTerm;
            string[] qTerm = q.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            TermWeighting QW = new TermWeighting();
            List<WeightedTerm> ListQueryWithWeight = new List<WeightedTerm>();
            foreach (var item in qTerm)
            {
                // add list element if not found in the list
                if (true) //term not found in the list
                {
                    //count weight of term
                    //wTerm = QW.CalculateTermWeighting(ListDocuments, i, j, 1, 1, 1);
                    wTerm = 10;
                    ListQueryWithWeight.Add(new WeightedTerm(item, wTerm));
                }

                //Console.Write(".");
                //Console.Write(item);
                //Console.Write(".");
            }
            foreach (var item in ListQueryWithWeight)
            {
                Console.Write("-" + item.term + "-" + item.weight + "-");
            }

        }
        static void Main(string[] args)
        {
            // read file
            string pathDocs = "D:/ADI/adi.all";
            string text = System.IO.File.ReadAllText(@pathDocs);

            // read queries
            string pathQueries = "D:/ADI/query.text";
            Queries qs = new Queries(pathQueries);
            qs.print();

            // read stopwords
            StopwordTool.AddDictionaryFromText(@"D:/stopwords.txt");

            // Split text per document
            string[] TextDocuments = text.Split(new string[] { ".I " }, StringSplitOptions.None);

            // Make Document Entities
            List<Document> ListDocuments = new List<Document>();
            for (int i = 1; i < TextDocuments.Count(); i++)
            {
                Document document = new Document(TextDocuments[i]);
                ListDocuments.Add(document);
            }

            TermWeighting TW = new TermWeighting(ListDocuments);
            List<string> ListTermWithWeight = new List<string>();

            for (int i = 0; i < ListDocuments.Count(); i++)
            {
                List<string> found = new List<string>();    // store word that has already counts
                for (int j = 0; j < ListDocuments.ElementAt(i).Content.Count(); j++)
                {
                    if (!found.Contains(ListDocuments.ElementAt(i).Content[j]))
                    {
                        found.Add(ListDocuments.ElementAt(i).Content[j]);

                        // menghitung term weight masing-masing kata di tiap dokumen
                        ListTermWithWeight.Add(ListDocuments.ElementAt(i).Content[j] + " " + ListDocuments.ElementAt(i).No + " " + TW.CalculateTermWeightingDocument(i, j, 1, 1, 1));
                    }
                }
            }

            ListTermWithWeight.Sort();

            using (StreamWriter writer = new StreamWriter(@"D:\InvertedFile.txt"))
            {
                foreach (string linestring in ListTermWithWeight)
                {
                    writer.WriteLine(linestring);
                }
            }

            // weighting each query's terms
            for (int i = 0; i < qs.nQuery(); i++)
            {
                weightQuery(qs.getQuery(i));
            }


            // untuk setiap dokumen di collection 
            // itung similaritynya : d1 - similarity


            //TODO menghilangkan index di content

            //// Test Term Weighting tiap kata tiap dokumen
            //for (int i = 0; i < ListDocuments.Count(); i++)
            //{
            //    List<string> found = new List<string>();    // store word that has already counts
            //    for (int j = 0; j < ListDocuments.ElementAt(i).Content.Count(); j++)
            //    {
            //        if (!found.Contains(ListDocuments.ElementAt(i).Content[j]))
            //        {
            //            found.Add(ListDocuments.ElementAt(i).Content[j]);

            //            // menghitung termweght masing-masing kata di tiap dokumen
            //            Console.WriteLine(ListDocuments.ElementAt(i).Content[j] + " : " + TW.CalculateTermWeighting(ListDocuments, i, j, 1, 1, 1));
            //        }
            //    }
            //}

            //using (StreamWriter writer = new StreamWriter(@"D:\InvertedFile.txt"))
            //{
            //    // Test Term Weighting tiap kata tiap dokumen
            //    for (int i = 0; i < ListDocuments.Count(); i++)
            //    {
            //        List<string> found = new List<string>();    // store word that has already counts
            //        for (int j = 0; j < ListDocuments.ElementAt(i).Content.Count(); j++)
            //        {
            //            if (!found.Contains(ListDocuments.ElementAt(i).Content[j]))
            //            {
            //                found.Add(ListDocuments.ElementAt(i).Content[j]);

            //                // menghitung term weight masing-masing kata di tiap dokumen
            //                writer.WriteLine(ListDocuments.ElementAt(i).Content[j] + " " + ListDocuments.ElementAt(i).No + " " + TW.CalculateTermWeighting(ListDocuments, i, j, 1, 1, 1));
            //            }
            //        }
            //    }
            //}

            //// Remove stopwords on title and content document
            //for (int i = 0; i < ListDocument.Count(); i++)
            //{
            //    //ListDocument.ElementAt(i).Title = StopwordTool.RemoveStopwords(ListDocument.ElementAt(i).Title);
            //    ListDocument.ElementAt(i).Content = StopwordTool.RemoveStopwords(ListDocument.ElementAt(i).Content);
            //}

            ////// Test print atribut Author salah satu document
            //for (int i = 0; i < ListDocument.ElementAt(57 - 1).Author.Count(); i++)
            //{
            //    Console.WriteLine(ListDocument.ElementAt(57 - 1).Author[i]);
            //}

            // Bagian content bisa dibuat menjadi, content + title

            ////// Test buat kelas Document
            //Console.WriteLine(new Document().Between(Documents[1], ".T", "\n.A"));

            ////// Test split text per document
            //Console.WriteLine(Documents[50]);
            //Console.WriteLine(Documents.Count());

            ////// Test Stopwords
            //Console.WriteLine(StopwordTool.RemoveStopwords(
            //    "I saw a cat and a horse"));
            //Console.WriteLine(StopwordTool.RemoveStopwords(
            //    "Google searches the Internet"));
            //Console.WriteLine(StopwordTool.RemoveStopwords(
            //    "Using an extra step"));
            Console.WriteLine("Selesai!!");
            Console.ReadLine();
        }
    }
}
