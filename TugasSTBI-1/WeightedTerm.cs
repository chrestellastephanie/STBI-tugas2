using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class WeightedTerm
    {
        public string term;
        public double weight;

        public WeightedTerm()
        {
            term = "";
            weight = 1;
        }
        public WeightedTerm(string text, double w)
        {
            term = text;
            weight = w;
        }
        public double getWeightFromFile(string pathDocs,string term, string docNum ){
            // read inverted file
            double weight = 0;
            System.IO.StreamReader file = new System.IO.StreamReader(@pathDocs);
            string line;
            string [] lineChunked;
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                lineChunked = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (lineChunked[0] == term && lineChunked[1] == docNum)
                {
                    weight =  Convert.ToDouble(lineChunked[2]);
                }
            }
            return weight;            
        }
    }
}
