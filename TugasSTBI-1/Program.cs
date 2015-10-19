using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Program
    {
        // return weight for each query term
        public static List<WeightedTermQuery> weightingQuery(string q, List<Document> ListDocuments)
        {
            double wTerm;

            string queryString = StopwordTool.RemoveStopwords(q);

            // Regex, untuk menghilangkan angka
            queryString = Regex.Replace(queryString, @"[0-9]+ ", string.Empty);

            // Stemming, mengubah kata ke bentuk dasarnya
            StemmingTool Stemmer = new StemmingTool();
            queryString = Stemmer.Stemming(queryString);


            string[] qTerm = queryString.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            TermWeighting QW = new TermWeighting(ListDocuments);
            List<WeightedTermQuery> ListQueryWithWeight = new List<WeightedTermQuery>();

            for (int i = 0; i < qTerm.Count(); i++)
            {
                List<string> found = new List<string>();    // store word that has already counts

                if (!found.Contains(qTerm[i]))
                {
                    found.Add(qTerm[i]);

                    // menghitung term weight masing-masing kata di tiap query
                    wTerm = QW.CalculateTermWeightingQuery(qTerm, i, 1, 1, 1);
                    ListQueryWithWeight.Add(new WeightedTermQuery(qTerm[i], wTerm));
                }
            }
            /*Print to console*/
            foreach (var item in ListQueryWithWeight)
            {
                Console.Write(item.term);
                Console.Write(item.weight);
                Console.Write("\n");
            }
            return ListQueryWithWeight;
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
            string outputInvertedFile = "D:/InvertedFile.txt";
            using (StreamWriter writer = new StreamWriter(@outputInvertedFile))
            {
                foreach (string linestring in ListTermWithWeight)
                {
                    writer.WriteLine(linestring);
                }
            }

               
            // list of hasil tiap query (list of list of result)
            List<List<Docvalue>> allResults = new List<List<Docvalue>>();
            //for each query
            for (int i = 0; i < qs.nQuery(); i++)
            {
                List<Docvalue> result = new List<Docvalue>();
                List<WeightedTermQuery> queryWithWeight = new List<WeightedTermQuery>();
                queryWithWeight = weightingQuery(qs.getQuery(i), ListDocuments);            
                Similarity sim = new Similarity(queryWithWeight, outputInvertedFile);
                result = sim.calculateDocumentsValue();
                result = result.OrderByDescending(o => o.val).ToList();
                allResults.Add(result);
            }

            //print hasil pencarian to console
            Console.WriteLine("RESULT : ");
            for (int i = 0; i < allResults.Count(); i++)
            {
                Console.WriteLine("result for query" + i);
                for (int j = 0; j < allResults.ElementAt(i).Count(); j++)
                {
                    Console.Write(allResults[i][j].docNum);
                    Console.Write("-");
                    Console.Write(allResults[i][j].val);
                    Console.Write("\n");
                }
            }
            
            //print hasil ke file

            string outputResult = "D:/SearchResult.txt";
            string line;
            using (StreamWriter writer = new StreamWriter(outputResult))
            {
                for (int i = 0; i < allResults.Count(); i++)
                {
                    for (int j = 0; j < allResults.ElementAt(i).Count(); j++)
                    {
                        line = i + 1 + " ";
                        line = line + allResults[i][j].docNum;
                        writer.WriteLine(line);
                    }
                }
            }

            



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
