using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Similarity
    {
        List<WeightedTermQuery> lQueryTerm;
        Dictionary<string, Dictionary<string, double>> lDocTerm; /*document which contains query term*/

        public Similarity()
        {
            lQueryTerm = null;
            lDocTerm = null;
        }

        public Similarity(List<WeightedTermQuery> lq/*, Dictionary<string, Dictionary<string, double>> invertedFileDict*/)
        {
            //Console.WriteLine("here");
            lQueryTerm = lq;
            //System.IO.StreamReader file = new System.IO.StreamReader(invertedFilePath);

            string line;
            string[] temp;

            lDocTerm = new Dictionary<string, Dictionary<string, double>>();
            foreach (var termInQuery in lq.Select(g => g.term).Distinct().ToList())
            {
                if (Program.dTermWeigth.ContainsKey(termInQuery)) //cek term query ada di inverted file ga
                {
                    if(!lDocTerm.ContainsKey(termInQuery)) //kalo term belom ada di lDocTerm. then bikin key baru di lDocterm
                    {
                        lDocTerm.Add(termInQuery, new Dictionary<string,double>());
                        foreach (var term in Program.dTermWeigth[termInQuery])
                        {
                            lDocTerm[termInQuery].Add(term.Key, term.Value);
                        }
                    }
                    else //kalo udah ada, then tambahin dari lDocterm[term] nya
                    {
                        foreach (var term in Program.dTermWeigth[termInQuery])
                        {
                            lDocTerm[termInQuery].Add(term.Key, term.Value);
                        }
                    }
                }
            }
            /*while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                temp = line.Split(' ');
                foreach(var item in lQueryTerm)
                {
                    if (item.term == temp[0])
                    {
                        lDocTerm.Add(new WeightedTermDoc(temp[0],temp[1],Convert.ToDouble(temp[2])));
                    }
                }
            }
             */ 

            /*foreach (var item in lDocTerm)
            {
                Console.WriteLine("ldocterm : " + item.term);
                Console.WriteLine("ldocterm : " + item.docNum);
            }
            foreach (var item in lQueryTerm)
            {
                Console.WriteLine("lquery : " + item.term);
            }*/
        }
        public List<Docvalue> calculateDocumentsValue()
        {
            // return docNum-value dari masing-masing dokumen yang akan diretrieve
            List<Docvalue> res = new List<Docvalue>();            

            //cari no dokumen yang distinct
            HashSet<string> docsNum = new HashSet<string>();
            foreach (var item in lDocTerm)
            {
                foreach(var subitem in item.Value)
                {
                    docsNum.Add(subitem.Key);
                }
            }
            //docsNum = docsNum.Distinct().ToList();

            // for each docNum, itung valuenya
            foreach (var item in docsNum)
            {
                res.Add(new Docvalue(item,calculateSim(item)));
            }
            return res;
        }
        public double calculateSim(string docnum)
        {
            double sim = 0;
            //Console.WriteLine("jumlah term query : " + lQueryTerm.Count());
            for (int i = 0; i < lQueryTerm.Count(); i++)
            {
                //Console.WriteLine("Term nya : " + lQueryTerm[i].weight);
                //double hasil = lQueryTerm[i].weight * getWeightFromDocList(lQueryTerm[i].term, docnum); 
                sim += lQueryTerm[i].weight * getWeightFromDocList(lQueryTerm[i].term,docnum);
                //Console.WriteLine(sim);
            }
            return sim;
        }

        public double getWeightFromDocList(string term, string docNum)
        {
            //return dari hash
            double w = 0;
            if(lDocTerm.ContainsKey(term))
            {
                if(lDocTerm[term].ContainsKey(docNum))
                {
                    w = lDocTerm[term][docNum];
                }
            }
            return w;
        }
        /*public double getWeightFromFile(string pathDocs, string term, string docNum)
        {
            // read inverted file
            double weight = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@pathDocs);
            string line;
            string[] lineChunked;
            while ((line = file.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                lineChunked = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (lineChunked[0] == term && lineChunked[1] == docNum)
                {
                    weight = Convert.ToDouble(lineChunked[2]);
                }
            }
            return weight;
        }*/

    }
}
