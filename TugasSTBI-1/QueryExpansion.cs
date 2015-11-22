using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasSTBI_1
{
    class QueryExpansion
    {
        public static void doQueryExpansion()
        {
            for (int i = 0; i < Program.relFeedback.Count; i++)
            {
                foreach (var item in Program.relFeedback[i])
                {
                    if (item.val == 1)
                    {
                        int no = Int32.Parse(item.docNum);
                        foreach (string term in Program.ListDocuments[no].Content)
                        {
                            if (!Program.lDQueryWeightNew[i].ContainsKey(term))
                            {
                                WeightedTermQuery wQuery = new WeightedTermQuery();
                                wQuery.term = term;
                                wQuery.weight = 0;
                                Program.lQueryWeightNew[i].Add(wQuery);
                                Program.lDQueryWeightNew[i].Add(term, 0);
                            }
                        }
                    }
                }
            }
        }
    }
}
