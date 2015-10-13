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
        public float weight;

        public WeightedTerm()
        {
            term = "";
            weight = 0;
        }
        public WeightedTerm(string text, float w)
        {
            term = text;
            weight = w;
        }
    }
}
