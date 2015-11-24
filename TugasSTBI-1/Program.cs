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
        public static List<Document> ListDocumentsFixed; /*List of Document master*/    
        public static List<Document> ListDocuments; /*List of Document*/
        public static Queries qs; /*list of query*/
        public static List<List<string>> relevantJudgements; /*list relevant judgement for queries*/
        public static List<Dictionary<String, int>> relevantJudgementsHash;
        public static List<List<Docvalue>> allResults;
        public static List<int> listOfNRelevantRetrieved; // jumlah relevan dokumen yang diretrieve               
        public static int tfDocCode, idfDocCode, normDocCode;
        public static int tfQueryCode, idfQueryCode, normQueryCode;
        public static int stemCode;
        public static string outputInvertedFile = "D:/InvertedFile.txt";
        public static string outputInvertedFile2 = "D:/InvertedFile2nd.txt"; // untuk 2nd retrieval
        //public static string relJudgPath = "D:/ADI/qrels.text";

        public static Dictionary<string, Dictionary<string, double>> dTermWeigth;
        public static Dictionary<string, Dictionary<string, int>> dDocuments;

        //relevance feedback
        public static int nRetrieve1 = -1; // jumlah top K dokumen yang diretrieve pertama kali
        public static string relevanceFeedbackMethod; //jenis metode yang dipilih untuk melakukan relevance feedback
        public static int useQueryExpansion; //apakah akan menggunakan query expansion
        public static int nPseudoRelevant;
        public static string secondDocCollection;
        public static List<HashSet<Docvalue>> relFeedback = new List<HashSet<Docvalue>>();
        public static HashSet<Docvalue> dvList = new HashSet<Docvalue>();
        public static Dictionary<string, int> dTitle_NumDoc = new Dictionary<string, int>(); //hashtable title-docnum. assigned when create inverted file.
        public static List<List<WeightedTermQuery>> lQueryWeightOld;
        public static List<List<WeightedTermQuery>> lQueryWeightNew;
        public static List<Dictionary<string, double>> lDQueryWeightNew;


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
            /*Console.Write("QUERY : ");
            foreach (var item in ListQueryWithWeight)
            {
                Console.Write(item.term);
                Console.Write(item.weight);
                Console.Write("\n");
            }*/
            return ListQueryWithWeight;
        }

        
        public static void findResultQueries(Queries queries, int k)
        {
            // list of hasil tiap query (list of list of result)
            allResults = new List<List<Docvalue>>();

            // list of list query old and new
            lQueryWeightOld = new List<List<WeightedTermQuery>>();
            lQueryWeightNew = new List<List<WeightedTermQuery>>();
            lDQueryWeightNew = new List<Dictionary<string, double>>();

            //for each query
            for (int i = 0; i < queries.nQuery(); i++)
            {
                List<Docvalue> result = new List<Docvalue>();
                List<WeightedTermQuery> queryWithWeight = new List<WeightedTermQuery>();
                queryWithWeight = weightingQuery(queries.getQuery(i), ListDocuments);
                
                lQueryWeightOld.Add(queryWithWeight);   // add list of query

                // initialize list new query, same as list old query 
                List<WeightedTermQuery> lQueryWeight = new List<WeightedTermQuery>();
                foreach (var item in queryWithWeight)
                {
                    WeightedTermQuery queryWeight = new WeightedTermQuery(item.term, item.weight);
                    lQueryWeight.Add(queryWeight);
                }
                lQueryWeightNew.Add(lQueryWeight);

                // initialize dictionary new query
                Dictionary<string, double> dQueryWeight = new Dictionary<string, double>();
                foreach(var item in queryWithWeight)
                {
                    if(!dQueryWeight.ContainsKey(item.term))
                    {
                        dQueryWeight.Add(item.term, item.weight);
                    }
                }
                lDQueryWeightNew.Add(dQueryWeight);
                //Console.WriteLine("query ke : " + i);
                Similarity sim = new Similarity(queryWithWeight, outputInvertedFile);
                result = sim.calculateDocumentsValue();
                result = result.OrderByDescending(o => o.val).ToList();
                if (k != -1) //-1 kalau hasil diretrieve semua
                {
                    result = result.Take(k).ToList();
                }    
                allResults.Add(result);
            }

            //print hasil pencarian to console
            /*
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
            }*/

            //print hasil ke file

            string outputResult = "D:/SearchResult.txt";
            string line;
            using (StreamWriter writer = new StreamWriter(outputResult))
            {
                //Console.WriteLine("jumlah allresult count " + allResults.Count());
                for (int i = 0; i < allResults.Count(); i++)
                {
                    //Console.WriteLine("jumlah result count " + i + (" : ") + allResults.ElementAt(i).Count());
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

        public static void findResultQueriesTopK(Queries queries, int k)
        {

        }
        public static void createInvertedFileFromListDocuments()
        {
            // Split text per document
            //string[] TextDocuments = documentsContent.Split(new string[] { ".I " }, StringSplitOptions.None);

            // Make Document Entities
            //ListDocuments = new List<Document>();
            //ListDocumentsFixed = new List<Document>();
            //dTitle_NumDoc = new Dictionary<String, int>();
            //dTitle_NumDoc.Add("lalala", 1);
            dDocuments = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 1; i < ListDocuments.Count(); i++)
            {
                //Console.WriteLine(TextDocuments[i]);
                Document document = ListDocuments[i];
                //Console.WriteLine(document.Title);
                //ListDocuments.Add(document);
                //dTitle_NumDoc.Add(document.Title, i);
                //Console.Write(document.Title);
                //Console.Write(" - ");
                //Console.Write(i);
                //Console.Write("\n");

                // input terms in document to dictionary
                foreach (string term in document.Content.Distinct())
                {
                    if (dDocuments.ContainsKey(term))
                    {
                        dDocuments[term].Add(document.No, (from s in document.Content where s == term select s).Count());
                    }
                    else
                    {
                        dDocuments.Add(term, new Dictionary<string, int>());
                        dDocuments[term].Add(document.No, (from s in document.Content where s == term select s).Count());
                    }
                }
            }

            //print dTitle_NumDoc
            /*
            foreach (var item in dTitle_NumDoc)
            {
                Console.Write(item.Key);
                Console.Write(" - ");
                Console.Write(item.Value);
                Console.Write("\n");
            }*/

            //uncomment
            TermWeighting TW = new TermWeighting(ListDocuments);
            List<string> ListTermWithWeight = new List<string>();

            dTermWeigth = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < ListDocuments.Count(); i++)
            {
                List<string> found = new List<string>();    // store word that has already counts
                for (int j = 0; j < ListDocuments.ElementAt(i).Content.Count(); j++)
                {
                    //Console.WriteLine(ListDocuments.ElementAt(i).Content[j]);
                    string term = ListDocuments.ElementAt(i).Content[j];
                    if (!found.Contains(ListDocuments.ElementAt(i).Content[j]))
                    {
                        found.Add(ListDocuments.ElementAt(i).Content[j]);

                        // menghitung term weight masing-masing kata di tiap dokumen
                        //ListTermWithWeight.Add(ListDocuments.ElementAt(i).Content[j] + " " + ListDocuments.ElementAt(i).No + " " + TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));

                        if (dTermWeigth.ContainsKey(term))  // dictionary already has the term 'key'
                        {
                            dTermWeigth[term].Add(ListDocuments.ElementAt(i).No, TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));
                        }
                        else    // dictionary not yet has the term 'key'
                        {
                            dTermWeigth.Add(term, new Dictionary<string, double>());
                            dTermWeigth[term].Add(ListDocuments.ElementAt(i).No, TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> entry in dTermWeigth)
            {
                string term = entry.Key;
                foreach (KeyValuePair<string, double> subEntry in entry.Value)
                {
                    string noDoc = subEntry.Key;
                    double weight = subEntry.Value;
                    ListTermWithWeight.Add(term + " " + noDoc + " " + weight);
                }
            }

            ListTermWithWeight.Sort();

            using (StreamWriter writer = new StreamWriter(@outputInvertedFile2))
            {
                foreach (string linestring in ListTermWithWeight)
                {
                    writer.WriteLine(linestring);
                }
            }
        }
        public static void createInvertedFile(string documentsContent)
        {
            // Split text per document
            string[] TextDocuments = documentsContent.Split(new string[] { ".I " }, StringSplitOptions.None);

            // Make Document Entities
            ListDocuments = new List<Document>();
            ListDocumentsFixed = new List<Document>();
            dTitle_NumDoc = new Dictionary<String, int>();
            //dTitle_NumDoc.Add("lalala", 1);
            dDocuments = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 1; i < TextDocuments.Count(); i++)
            {
                //Console.WriteLine(TextDocuments[i]);
                Document document = new Document(TextDocuments[i], stemCode);
                //Console.WriteLine(document.Title);
                ListDocuments.Add(document);
                ListDocumentsFixed.Add(document);
                string ttl = document.Title + "|||" + i;
                dTitle_NumDoc.Add(ttl, i);
                /*
                Console.Write(document.Title);
                Console.Write(" - ");
                Console.Write(i);
                Console.Write("\n");
                 */

                // input terms in document to dictionary
                foreach (string term in document.Content.Distinct())
                {
                    if (dDocuments.ContainsKey(term))
                    {
                        dDocuments[term].Add(document.No, (from s in document.Content where s == term select s).Count());
                    }
                    else
                    {
                        dDocuments.Add(term, new Dictionary<string, int>());
                        dDocuments[term].Add(document.No, (from s in document.Content where s == term select s).Count());
                    }
                }
            }

            //print dTitle_NumDoc
            /*foreach (var item in dTitle_NumDoc)
            {
                Console.Write(item.Key);
                Console.Write(" - ");
                Console.Write(item.Value);
                Console.Write("\n");
            }*/

            //uncomment
            TermWeighting TW = new TermWeighting(ListDocuments);
            List<string> ListTermWithWeight = new List<string>();

            dTermWeigth = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < ListDocuments.Count(); i++)
            {
                List<string> found = new List<string>();    // store word that has already counts
                for (int j = 0; j < ListDocuments.ElementAt(i).Content.Count(); j++)
                {
                    //Console.WriteLine(ListDocuments.ElementAt(i).Content[j]);
                    string term = ListDocuments.ElementAt(i).Content[j];
                    if (!found.Contains(ListDocuments.ElementAt(i).Content[j]))
                    {
                        found.Add(ListDocuments.ElementAt(i).Content[j]);

                        // menghitung term weight masing-masing kata di tiap dokumen
                        //ListTermWithWeight.Add(ListDocuments.ElementAt(i).Content[j] + " " + ListDocuments.ElementAt(i).No + " " + TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));

                        if (dTermWeigth.ContainsKey(term))  // dictionary already has the term 'key'
                        {
                            dTermWeigth[term].Add(ListDocuments.ElementAt(i).No, TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));
                        }
                        else    // dictionary not yet has the term 'key'
                        {
                            dTermWeigth.Add(term, new Dictionary<string, double>());
                            dTermWeigth[term].Add(ListDocuments.ElementAt(i).No, TW.CalculateTermWeightingDocument(i, j, tfDocCode, idfQueryCode, normDocCode));
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Dictionary<string, double>> entry in dTermWeigth)
            {
                string term = entry.Key;
                foreach (KeyValuePair<string, double> subEntry in entry.Value)
                {
                    string noDoc = subEntry.Key;
                    double weight = subEntry.Value;
                    ListTermWithWeight.Add(term + " " + noDoc + " " + weight);
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

        public static void readRelJudg(string pathRelJudg)
        {
            relevantJudgements = new List<List<string>>();
            relevantJudgementsHash = new List<Dictionary<string, int>>();
            List<string> rjPerQuery = new List<string>();
            string relJudgText = System.IO.File.ReadAllText(@pathRelJudg);
            string[] rjLine;
            string[] rjChunked;
            rjLine = relJudgText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine("jumlah relevan judg : " + rjLine.Count());
            for (int i = 0; i < rjLine.Count(); i++)
            {
                //Console.WriteLine(rjLine[i]);
                rjChunked = rjLine[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine(rjLine[i]);
                while (relevantJudgements.Count() != Int32.Parse(rjChunked[0])) //di list belum ada list untuk query ke i
                {
                    relevantJudgements.Add(new List<string>());
                    relevantJudgementsHash.Add(new Dictionary<string,int>());
                }
                // rjChunked[1] : no dokumen yang relevan untuk no query rjChunked[0]
                relevantJudgements.ElementAt(Int32.Parse(rjChunked[0]) - 1).Add(rjChunked[1]);
                relevantJudgementsHash.ElementAt(Int32.Parse(rjChunked[0]) - 1).Add(rjChunked[1],1);
                //Console.WriteLine(Int32.Parse(rjChunked[0]) - 1 + " -- " + rjChunked[1]);
            }
            // print relevant judgement to console
            //Console.WriteLine("ini rel judgnya");
            /*
            for (int i = 0; i < relevantJudgements.Count(); i++)
            {
                for (int j = 0; j < relevantJudgements.ElementAt(i).Count(); j++)
                {
                    Console.Write(relevantJudgements.ElementAt(i).ElementAt(j));
                    Console.Write("-");
                }
                Console.Write("\n");
            }*/
            // print relevant judgement hashtable to console
            /*Console.WriteLine("ini rel judgement yang hash");
            
            for (int i = 0; i < relevantJudgementsHash.Count(); i++)
            {
                for (int j = 0; j < relevantJudgementsHash.ElementAt(i).Count(); j++)
                {
                    Console.Write(relevantJudgementsHash.ElementAt(i).ElementAt(j).Key);
                    Console.Write("-");
                    Console.Write(relevantJudgementsHash.ElementAt(i).ElementAt(j).Value);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }*/
        }

        public static void nRelevantRetrieved(List<List<Docvalue>> allRes, List<List<string>> allRelJudg)
        {
            int n = 0;
            listOfNRelevantRetrieved = new List<int>();
            for (int i = 0; i < allRes.Count(); i++)
            {
                //Console.WriteLine("result for query" + i);
                n = 0;
                for (int j = 0; j < allRes.ElementAt(i).Count(); j++)
                {
                    //Console.WriteLine(i);
                    if (allRelJudg[i].Count() != 0)
                    {
                        if (allRelJudg[i].Contains(allRes[i][j].docNum))
                        {
                            //Console.Write(i);
                            //Console.Write("...");
                            //Console.Write(allRes[i][j].docNum);
                            //Console.Write("-");
                            //Console.Write(allRes[i][j].val);
                            //Console.Write("\n");
                            n++;
                        }
                    }
                }
                listOfNRelevantRetrieved.Add(n);
            }
            /*
            for (int i = 0; i < listOfNRelevantRetrieved.Count(); i++)
            {
                Console.Write("yang relevan untuk query " + i + ":" );
                Console.Write(listOfNRelevantRetrieved.ElementAt(i));
                Console.Write("\n");
            }*/
        }
        public static double calculateRecall(int queryNumber)
        {
            double recall = 0;

            recall = (double)listOfNRelevantRetrieved.ElementAt(queryNumber) / (double)relevantJudgements.ElementAt(queryNumber).Count();
            //Console.WriteLine("jumlah benar yang diretrieve : " + listOfNRelevantRetrieved.ElementAt(queryNumber));
            //Console.WriteLine("banyaknya dokumen yang relevan pada collection : " + relevantJudgements.ElementAt(queryNumber).Count());
            //Console.WriteLine("Recall  : " + recall);
            return recall;
        }
        public static double calculatePrecision(int queryNumber)
        {
            double precision = 0;
            precision = (double)listOfNRelevantRetrieved.ElementAt(queryNumber) / (double)allResults.ElementAt(queryNumber).Count();
            return precision; 
        }
        public static double AveragePrecision(int queryNumber)
        {
            double AveragePrecision = 0;
            int relevant = 0;
            for (int j = 0; j < allResults.ElementAt(queryNumber).Count(); j++)
            {
                if (relevantJudgements[queryNumber].Contains(allResults[queryNumber][j].docNum))
                {
                    relevant++;
                    AveragePrecision = AveragePrecision + (double)relevant / (double)(j + 1);
                }
            }
            return AveragePrecision;
        }
        public static double calculateNIAP(int queryNumber)
        {
            double NIAP = 0;
            NIAP = AveragePrecision(queryNumber) / (double)relevantJudgements.ElementAt(queryNumber).Count();
            //Console.WriteLine("NIAP = " + NIAP);
            return NIAP;
        }
        public static void mainProgram(string pathDocs, string pathQueries, string pathRel, string pathStopWord)
        {
            // read file
            string text = System.IO.File.ReadAllText(@pathDocs);

            // read queries
            qs = new Queries(@pathQueries);
            //qs.print();

            // read stopwords
            StopwordTool.AddDictionaryFromText(@pathStopWord);

            createInvertedFile(text); //uncomment
        }

        /*public static string getDocNum(string title)
        {
            string docNum = "";

            return docNum;
        }*/

        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new IndexingForm());
            //Application.Run(new relevanceFeedbackForm());
        }
    }
}
