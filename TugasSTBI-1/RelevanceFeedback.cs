using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class RelevanceFeedback
    {
        
        public static double calculateNewQuery(double wQueryOld, List<double> relevant, List<double> irrelevant)
        {
            double result = 0;
            switch (Program.relevanceFeedbackMethod)
            {
                case "rochio":
                    result = rochio(wQueryOld, relevant, irrelevant);
                    break;
                case "regular":
                    result = ideReg(wQueryOld, relevant, irrelevant);
                    break;
                case "dechi":
                    result = ideDecHi(wQueryOld, relevant, irrelevant[0]);
                    break;
                case "pseudo":
                    result = rochio(wQueryOld, relevant, irrelevant);
                    break;
            }

            return result;
        }

        public static List<double> CreateRelevant(string term, int querynumber)
        {
            List<double> relevant = new List<double>();
            for (int i = 0; i <= Program.relFeedback[querynumber].Count - 1; i++)
            {
                if (Program.relFeedback.ElementAt(querynumber).ElementAt(i).val == 1)
                {
                    double weight = 0;
                    if (Program.dTermWeigth.ContainsKey(term))
                    {
                        string no = Program.relFeedback.ElementAt(querynumber).ElementAt(i).docNum;
                        if(Program.dTermWeigth[term].ContainsKey(no))
                        {
                            weight = Program.dTermWeigth[term][no];
                        }
                    }
                    relevant.Add(weight);
                }
            }

            if(relevant.Count == 0)
            {
                relevant.Add(0);
            }

            return relevant;
        }

        public static List<double> CreateIrrelevant(string term, int querynumber)
        {
            List<double> irrelevant = new List<double>();
            for (int i = 0; i <= Program.relFeedback[querynumber].Count - 1; i++)
            {
                if (Program.relFeedback.ElementAt(querynumber).ElementAt(i).val == 0)
                {
                    double weight = 0;
                    if (Program.dTermWeigth.ContainsKey(term))
                    {
                        string no = Program.relFeedback.ElementAt(querynumber).ElementAt(i).docNum;
                        if (Program.dTermWeigth[term].ContainsKey(no))
                        {
                            weight = Program.dTermWeigth[term][no];
                        }
                    }
                    irrelevant.Add(weight);
                }
            }

            if (irrelevant.Count == 0)
            {
                irrelevant.Add(0);
            }

            return irrelevant;
        }

        private static double rochio(double wQueryOld, List<double> relevant, List<double> irrelevant)
        {
            double result;
            result = wQueryOld + (relevant.Sum() / relevant.Count) - (irrelevant.Sum() / irrelevant.Count);

            return result;
        }

        private static double ideReg(double wQueryOld, List<double> relevant, List<double> irrelevant)
        {
            double result;
            result = wQueryOld + relevant.Sum() - irrelevant.Sum();

            return result;
        }

        private static double ideDecHi(double wQueryOld, List<double> relevant, double irrelevant)
        {
            double result;
            result = wQueryOld + relevant.Sum() - irrelevant;

            return result;
        }

        public static void reWeightingQuery()
        {
            int iter = 0;
            foreach(var query in Program.lQueryWeightNew)
            {
                int iter1 = 0;
                foreach(var item in query)
                {
                    List<double> relevant = CreateRelevant(item.term, iter);
                    List<double> irrelevant = CreateIrrelevant(item.term, iter);
                    double newWeight = calculateNewQuery(item.weight, relevant, irrelevant);
                    Program.lDQueryWeightNew[iter][item.term] = newWeight;
                    Program.lQueryWeightNew[iter][iter1].weight = newWeight;
                    iter1++;
                }
                iter++;
            }

            removeQuery();
        }

        public static void reCalculateSimilarity(int k)
        {
            Program.allResults = new List<List<Docvalue>>();
            for (int i = 0; i < Program.lQueryWeightNew.Count; i++)
            {
                List<Docvalue> result = new List<Docvalue>();
                Similarity sim = new Similarity(Program.lQueryWeightNew[i] , Program.outputInvertedFile);
                result = sim.calculateDocumentsValue();
                result = result.OrderByDescending(o => o.val).ToList();
                if (k != -1) //-1 kalau hasil diretrieve semua
                {
                    result = result.Take(k).ToList();
                }
                Program.allResults.Add(result);
            }
        }

        public static void assignRelFeedback()
        {
            Program.relFeedback = new List<HashSet<Docvalue>>();
            foreach(var item in Program.lQueryWeightOld)
            {
                HashSet<Docvalue> query = new HashSet<Docvalue>();
                query.Add(new Docvalue("1", 1));
                Program.relFeedback.Add(query);
            }
        }

        private static void removeQuery()
        {
            int iter = 0;
            foreach (var item in Program.lQueryWeightNew)
            {
                foreach (var subitem in item.Where(v => v.weight <= 0).ToList())
                {
                    Program.lQueryWeightNew[iter].Remove(subitem);
                    Program.lDQueryWeightNew[iter].Remove(subitem.term);
                }
                iter++;
            }
        }
    }
}
