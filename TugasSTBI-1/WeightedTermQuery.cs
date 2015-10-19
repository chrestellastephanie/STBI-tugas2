using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class WeightedTermQuery
    {
        public string term;
        public double weight;

        public WeightedTermQuery()
        {
            term = "";
            weight = 1;
        }
        public WeightedTermQuery(string text, double w)
        {
            term = text;
            weight = w;
        }
        
    }
}
