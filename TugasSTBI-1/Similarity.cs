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
        List<WeightedTermDoc> lDocTerm; /*document which contain query term*/

        public Similarity()
        {
            lQueryTerm = null;
            lDocTerm = null;
        }

        public Similarity(List<WeightedTermQuery> lq, string invertedFilePath)
        {
            //Console.WriteLine("here");
            lQueryTerm = lq;
            System.IO.StreamReader file = new System.IO.StreamReader(invertedFilePath);
            string line;
            string[] temp;
            lDocTerm = new List<WeightedTermDoc>();
            while ((line = file.ReadLine()) != null)
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
            List<string> docsNum = new List<string>();
            foreach (var item in lDocTerm)
            {
                docsNum.Add(item.docNum);
            }
            docsNum.Distinct();

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
            for (int i = 0; i < lQueryTerm.Count(); i++)
            {
                sim += lQueryTerm[i].weight * getWeightFromDocList(lQueryTerm[i].term,docnum);
            }
            return sim;
        }

        public double getWeightFromDocList(string term, string docNum)
        {
            double w = 0;
            foreach (var item in lDocTerm)
            {
                if (item.term == term && item.docNum==docNum)
                {
                    w = item.weight;
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
