using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class Docvalue
    {
        public string docNum{get;set;}
        public double val{get;set;}

        public Docvalue(string num, double value)
        {
            docNum = num;
            val = value;
        }
    }
}
