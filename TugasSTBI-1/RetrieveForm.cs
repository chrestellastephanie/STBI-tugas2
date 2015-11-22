using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasSTBI_1
{
    public partial class RetrieveForm : Form
    {
        public RetrieveForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxInteractiveQuery.Visible = true;
            buttonInteractiveSearch.Visible = true;
            listBoxResultInteractive.Visible = true;
            labelResult.Visible = true;
        }

        private void buttonInteractiveSearch_Click(object sender, EventArgs e)
        {
            //here
            Queries interactiveQuery = new Queries();
            interactiveQuery.query[0] = textBoxInteractiveQuery.Text;
            //Program.qs.query = textBoxInteractiveQuery.Text.Split(' ');
            Program.findResultQueries(interactiveQuery, Program.nRetrieve1);
            
            //// test relevance
            //RelevanceFeedback.assignRelFeedback();
            //QueryExpansion.doQueryExpansion();
            //RelevanceFeedback.reWeightingQuery();

            listBoxResultInteractive.Items.Clear();
            string line;
            int nd;
            
            for (int i = 0; i < Program.allResults.Count(); i++)
            {
                for (int j = 0; j < Program.allResults.ElementAt(i).Count(); j++)
                {
                    line = j + 1 + ". ";
                    //line = line + ("--w = ") + Program.allResults[i][j].val + ("-- ");
                    nd = Int32.Parse(Program.allResults[i][j].docNum)-1;
                    //line = line + ("(") + Program.ListDocuments[nd].No + (")");
                    //line = line + (" - ");
                    line = line + Program.ListDocuments[nd].Title;
                    listBoxResultInteractive.Items.Add(line);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) //experiment button
        {
            textBoxInteractiveQuery.Visible = false;
            buttonInteractiveSearch.Visible = false;
            listBoxResultInteractive.Visible = true;
            labelResult.Visible = true;

            Program.readRelJudg(IndexingForm.relevanceDirectory);
            Program.findResultQueries(Program.qs, Program.nRetrieve1);

            //// print list query
            //int iter = 0;
            //foreach(var item in Program.lQueryWeightOld)
            //{
            //    int iter1 = 0;
            //    foreach(var subitem in item)
            //    {
            //        Console.WriteLine(subitem.term + " " + subitem.weight);
            //        Console.WriteLine(Program.lQueryWeightNew[iter][iter1].term + " " + Program.lQueryWeightNew[iter][iter1].weight);
            //        Console.WriteLine(Program.lDQueryWeightNew[iter][subitem.term]);
            //        iter1++;
            //    }
            //    iter++;
            //}

            Program.nRelevantRetrieved(Program.allResults, Program.relevantJudgements);

            
            listBoxResultInteractive.Items.Clear();
            string line;
            int nd;
            double meanRecall = 0;
            double meanPrecision = 0;
            double meanNIAP = 0;
            for (int i = 0; i < Program.allResults.Count(); i++)
            {
                listBoxResultInteractive.Items.Add("Result for query #" + (i+1));
                listBoxResultInteractive.Items.Add(Program.qs.query[i]);
                listBoxResultInteractive.Items.Add("Recall = " + Program.calculateRecall(i));
                listBoxResultInteractive.Items.Add("Precision = " + Program.calculatePrecision(i));
                listBoxResultInteractive.Items.Add("Non-Interpolated Average Precision = " + Program.calculateNIAP(i));
                meanRecall = meanRecall + Program.calculateRecall(i);
                meanPrecision = meanPrecision+ Program.calculatePrecision(i);
                meanNIAP = meanNIAP + Program.calculateNIAP(i);
                
                for (int j = 0; j < Program.allResults.ElementAt(i).Count(); j++)
                {
                    line = j + 1 + ". ";
                    //line = line + ("--w = ") + Program.allResults[i][j].val + ("-- ");
                    nd = Int32.Parse(Program.allResults[i][j].docNum) - 1;
                    //line = line + ("(") + Program.ListDocuments[nd].No + (")");
                    //line = line + (" - ");
                    line = line + Program.ListDocuments[nd].Title;
                    listBoxResultInteractive.Items.Add(line);
                }
                listBoxResultInteractive.Items.Add("\n");
            }
            meanRecall = meanRecall / Program.allResults.Count();
            meanPrecision = meanPrecision / Program.allResults.Count();
            meanNIAP = meanNIAP / Program.allResults.Count();
            listBoxResultInteractive.Items.Add("Mean Recall: " + meanRecall);
            listBoxResultInteractive.Items.Add("Mean Precision: " + meanPrecision);
            listBoxResultInteractive.Items.Add("Mean Non interpolated average precision: " + meanNIAP);

        }

        private void RetrieveForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listBoxResultInteractive_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxResultInteractive.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(index.ToString());
            }
            
        }

        /*private void listBoxResultInteractive_DoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxResultInteractive.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                MessageBox.Show(index.ToString());
            }
        }*/

        private void listBoxResultInteractive_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int index = this.listBoxResultInteractive.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //MessageBox.Show(listBoxResultInteractive.SelectedItem.ToString());
                //MessageBox.Show("Apakah dokumen ini relevan?");
                var relevantForm = new relevanceFeedbackForm();
                relevantForm.setTitle(listBoxResultInteractive.SelectedItem.ToString());
                relevantForm.Show(this);
            }
        }
    }
}
