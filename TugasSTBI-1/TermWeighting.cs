using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class TermWeighting
    {
        public List<Document> Documents { get; set; }

        public TermWeighting(List<Document> _Documents)
        {
            Documents = _Documents;
        }

        public int RawTf (string [] content, string term)
        {
            int sum = CountTermInDocument(content, term);

            return sum;
        }

        private int CountTermInDocument (string [] content, string term)
        {
            int sum = 0;
            foreach (string word in content)
            {
                if (word.Equals(term))
                {
                    sum++;
                }
            }

            return sum;
        }

        public double LogTf(string[] content, string term)
        {
            double result = 0;
            int sum = CountTermInDocument(content, term);

            if(sum != 0)
            {
                result = 1 + Math.Log10(sum);
            }
            
            return result;
        }

        public int BinaryTf (string [] content, string term)
        {
            int result = 0;
            if(content.Contains(term))
            {
                result = 1;
            }

            return result;
        }

        public double AugmentedTf (string [] content, string term)
        {
            double result = 0;
            int sum = CountTermInDocument(content, term);            // count tf term in content

            if (sum != 0)
            {
                int maxTf = FindMaxTf (content);
                result = 0.5 + (double) (0.5 * sum / maxTf);
            }

            return result;
        }

        private int FindMaxTf (string [] content)
        {
            // count tf each word in document
            List<string> found = new List<string>();    // store word that has already counts
            int maxTf = 0;                              // store value of max tf
            for (int i = 0; i < content.Count(); i++)
            {
                if (!found.Contains(content[i]))
                {
                    found.Add(content[i]);

                    int SumEachWord = 0;
                    string term1 = content[i];
                    for (int j = i; j < content.Count(); j++)
                    {
                        if (content[j].Equals(term1))
                        {
                            SumEachWord++;
                        }
                    }

                    // find max tf
                    if (SumEachWord > maxTf)
                    {
                        maxTf = SumEachWord;
                    }
                }
            }

            return maxTf;
        }

        public int noTf()
        {
            return 1;
        }

        public double Idf (string term)
        {
            double result = 0;
            int sum = 0;
            foreach (var document in Documents)
            {
                if (document.Content.Contains(term))
                {
                    sum++;
                }
            }

            if (sum != 0)
            {
                result = Math.Log10((double)Documents.Count / sum);
            }

            return result;
        }

        public int NoIdf ()
        {
            return 1;
        }

        public double Normalization (string [] content)
        {
            List<int> ListSum = FindSumEachTerm(content);
            double result = Math.Sqrt(SumQuadrate(ListSum));

            return result;
        }

        private long SumQuadrate (List<int> ListSum)
        {
            long sum = 0;

            foreach(int count in ListSum)
            {
                sum += (count * count);
            }

            return sum;
        }

        private List<int> FindSumEachTerm(string[] content)
        {
            // count tf each word in document
            List<int> ListSum = new List<int>();
            List<string> found = new List<string>();    // store word that has already counts
            for (int i = 0; i < content.Count(); i++)
            {
                if (!found.Contains(content[i]))
                {
                    found.Add(content[i]);

                    int SumEachWord = 0;
                    string term1 = content[i];
                    for (int j = i; j < content.Count(); j++)
                    {
                        if (content[j].Equals(term1))
                        {
                            SumEachWord++;
                        }
                    }
                    ListSum.Add(SumEachWord);
                }
            }

            return ListSum;
        }

        public int NoNormalization ()
        {
            return 1;
        }

        public double CalculateTermWeightingDocument(int NoDocument, int NoTerm, int TfCode, int IdfCode, int NormalizationCode)
        {
            double tf = CalculateTf(Documents.ElementAt(NoDocument).Content, Documents.ElementAt(NoDocument).Content[NoTerm], TfCode);
            double idf = CalculateIdf(Documents.ElementAt(NoDocument).Content[NoTerm], IdfCode);
            double normalization = CalculateNormalization(Documents.ElementAt(NoDocument).Content, NormalizationCode);

            return tf * idf / normalization;
        }

        public double CalculateTermWeightingQuery(string[] content, int noTerm, int tfCode, int idfCode, int normalizationCode)
        {
            double tf = CalculateTf(content, content[noTerm], tfCode);
            double idf = CalculateIdf(content[noTerm], idfCode);
            double normalization = CalculateNormalization(content, normalizationCode);

            return tf * idf / normalization;
        }

        private double CalculateTf(string [] content, string term, int code)
        {
            double result = 0;
            switch (code)
            {
                case 0:
                    result = (double)noTf();
                    break;
                case 1:
                    result = (double)RawTf(content, term);
                    break;
                case 2:
                    result = LogTf(content, term);
                    break;
                case 3:
                    result = (double)BinaryTf(content, term);
                    break;
                case 4:
                    result = AugmentedTf(content, term);
                    break;
            }

            return result;
        }

        private double CalculateIdf(string term, int code)
        {
            double result = 0;
            switch (code)
            {
                case 0:
                    result = (double)NoIdf();
                    break;
                case 1:
                    result = Idf(term);
                    break;
            }

            return result;
        }

        private double CalculateNormalization (string [] content, int code)
        {
            double result = 0;
            switch (code)
            {
                case 0:
                    result = (double)NoNormalization();
                    break;
                case 1:
                    result = Normalization(content);
                    break;
            }

            return result;
        }
    }
}
