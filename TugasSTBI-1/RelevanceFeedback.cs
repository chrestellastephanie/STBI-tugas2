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
    }
}
