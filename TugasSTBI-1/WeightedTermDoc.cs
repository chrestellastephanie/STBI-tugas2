using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class WeightedTermDoc
    {
        public string term{get; set;}
        public string docNum{get; set;}
        public double weight{get; set;}

        public WeightedTermDoc()
        {
            term = "";
            docNum = "0";
            weight = 0;
        }

        public WeightedTermDoc(string t, string n, double w)
        {
            term = t;
            docNum = n;
            weight = w;
        }
    }
}
