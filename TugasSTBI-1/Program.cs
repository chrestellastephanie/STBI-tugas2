using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasSTBI_1
{
    class Program
    {
        // Global variable
        public static List<Document> ListDocuments; /*List of Document*/
        public static Queries qs; /*list of query*/
        public static List<List<string>> relevantJudgements; /*list relevant judgement for queries*/
        public static List<List<Docvalue>> allResults;
        public static int tfDocCode, idfDocCode, normDocCode;
        public static int tfQueryCode, idfQueryCode, normQueryCode;
        public static int stemCode;
        public static string outputInvertedFile = "D:/InvertedFile.txt";
        public static string relJudgPath = "D:/ADI/qrels.text";

        // return weight for each query term
        public static List<WeightedTermQuery> weightingQuery(string q, List<Document> ListDocuments)
        {
            double wTerm;

            string queryString = StopwordTool.RemoveStopwords(q);

            // Regex, untuk menghilangkan angka
            queryString = Regex.Replace(queryString, @"[0-9]+ ", string.Empty);

            if(stemCode == 1)
            {
                // Stemming, mengubah kata ke bentuk dasarnya
                StemmingTool Stemmer = new StemmingTool();
                queryString = Stemmer.Stemming(queryString);
            }

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
                    wTerm = QW.CalculateTermWeightingQuery(qTerm, i, tfQueryCode, idfQueryCode, normQueryCode);
                    //wTerm = 1;
                    ListQueryWithWeight.Add(new WeightedTermQuery(qTerm[i], wTerm));
                }
            }
            /*Print to console*/
            Console.Write("QUERY : ");
            foreach (var item in ListQueryWithWeight)
            {
                Console.Write(item.term);
                Console.Write(item.weight);
                Console.Write("\n");
            }
            return ListQueryWithWeight;
        }

        
        public static void findResultQueries(Queries queries)
        {
            // list of hasil tiap query (list of list of result)
            allResults = new List<List<Docvalue>>();
            //for each query
            for (int i = 0; i < queries.nQuery(); i++)
            {
                List<Docvalue> result = new List<Docvalue>();
                List<WeightedTermQuery> queryWithWeight = new List<WeightedTermQuery>();
                queryWithWeight = weightingQuery(queries.getQuery(i), ListDocuments);
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
                Console.WriteLine("jumlah allresult count " + allResults.Count());
                for (int i = 0; i < allResults.Count(); i++)
                {
                    Console.WriteLine("jumlah result count " + allResults.ElementAt(i).Count());
                    for (int j = 0; j < allResults.ElementAt(i).Count(); j++)
                    {
                        line = i + 1 + " ";
                        line = line + allResults[i][j].docNum;
                        writer.WriteLine(line);
                    }
                }
            }

            Console.WriteLine("Selesai!!");
            Console.ReadLine();
        }

 
        public static void createInvertedFile(string documentsContent)
        {
            // Split text per document
            string[] TextDocuments = documentsContent.Split(new string[] { ".I " }, StringSplitOptions.None);

            // Make Document Entities
            ListDocuments = new List<Document>();
            for (int i = 1; i < TextDocuments.Count(); i++)
            {
                Document document = new Document(TextDocuments[i], stemCode);
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
                        ListTermWithWeight.Add(ListDocuments.ElementAt(i).Content[j] + " " + ListDocuments.ElementAt(i).No + " " + TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));
                    }
                }
            }

            ListTermWithWeight.Sort();
            
            using (StreamWriter writer = new StreamWriter(@outputInvertedFile))
            {
                foreach (string linestring in ListTermWithWeight)
                {
                    writer.WriteLine(linestring);
                }
            }
        }

        public static void readRelJudg()
        {
            relevantJudgements = new List<List<string>>();
            List<string> rjPerQuery = new List<string>();
            string relJudgText = System.IO.File.ReadAllText(@relJudgPath);
            string[] rjLine;
            string[] rjChunked;
            rjLine = relJudgText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rjLine.Count(); i++)
            {
                Console.WriteLine(rjLine[i]);
                rjChunked = rjLine[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (relevantJudgements.Count() < Int32.Parse(rjChunked[0])) //di list belum ada list untuk query ke i
                {
                    relevantJudgements.Add(new List<string>());
                }
                relevantJudgements.ElementAt(Int32.Parse(rjChunked[0]) - 1).Add(rjChunked[1]);
            }
            // print relevant judgement to console
            Console.WriteLine("ini rel judgnya");
            for (int i = 0; i < relevantJudgements.Count(); i++)
            {
                for (int j = 0; j < relevantJudgements.ElementAt(i).Count(); j++)
                {
                    Console.Write(relevantJudgements.ElementAt(i).ElementAt(j));
                    Console.Write("-");
                }
                Console.Write("\n");
            }
        }

        public int nRelevantRetrieved(List<List<Docvalue>> allRes, List<List<string>> allRelJudg)
        {
            int n = 0;
            // terakhir sampe sini

            return n;
        }

        public static void mainProgram(string pathDocs, string pathQueries, string pathRel, string pathStopWord)
        {
            // read file
            string text = System.IO.File.ReadAllText(@pathDocs);

            // read queries
            qs = new Queries(@pathQueries);
            qs.print();

            // read stopwords
            StopwordTool.AddDictionaryFromText(@pathStopWord);

            createInvertedFile(text);
            //findResultQueries(qs);
            readRelJudg();
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IndexingForm());
        }
    }
}
