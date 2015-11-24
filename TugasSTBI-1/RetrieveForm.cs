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

        private void button2_Click(object sender, EventArgs e) //button interactive
        {
            textBoxInteractiveQuery.Visible = true;
            buttonInteractiveSearch.Visible = true;
            listBoxResultInteractive.Visible = true;
            listBoxResultInteractive.Items.Clear();
            Program.modeUsed = "interactive";
            if (!Program.relevanceFeedbackMethod.Equals("pseudo"))
            {
                buttonSecondRetrieval.Visible = true;
            }
            labelResult.Visible = true;
        }

        private void buttonInteractiveSearch_Click(object sender, EventArgs e)
        {
            //here
            Queries interactiveQuery = new Queries();
            interactiveQuery.query[0] = textBoxInteractiveQuery.Text;
            //Program.qs.query = textBoxInteractiveQuery.Text.Split(' ');
            Program.findResultQueries(interactiveQuery, Program.nRetrieve1);

            if (Program.relevanceFeedbackMethod.Equals("pseudo"))
            {
                RelevanceFeedback.assignRelFeedback(); //kalo pseudo yang top N dianggap relevan
                Program.createInvertedFileFromListDocuments();

                if (Program.useQueryExpansion == 1)
                {
                    QueryExpansion.doQueryExpansion();
                }
                RelevanceFeedback.reWeightingQuery();
                RelevanceFeedback.reCalculateSimilarity(-1);
            }

            //reset listdocuments
            Program.ListDocuments.Clear();
            Program.ListDocuments = new List<Document>(Program.ListDocumentsFixed);

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
                    line = line + ("similarity = ") + Program.allResults[i][j].val + ("-- ");
                    nd = Int32.Parse(Program.allResults[i][j].docNum)-1;
                    line = line + ("((") + Program.ListDocuments[nd].No + ("))");
                    line = line + (" ---- ");
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
            buttonSecondRetrieval.Visible = false;
            Program.modeUsed = "experiment";
            labelResult.Visible = true;

            //reset list documents
            Program.ListDocuments.Clear();
            Program.ListDocuments = new List<Document>(Program.ListDocumentsFixed);
            Console.WriteLine("test");

            Program.readRelJudg(IndexingForm.relevanceDirectory);
            Program.findResultQueries(Program.qs, Program.nRetrieve1); //first retrieve
            RelevanceFeedback.assignRelFeedback();

            //if (Program.secondDocCollection.Equals("diff"))
            //{
            //    int count = Program.relFeedback.Count(); //menghitung jumlah feedback yang diberikan user
            //    List<string> judgedDocNum = new List<string>(); //list of judged documents number
            //    foreach (var item in Program.relFeedback)
            //    {
            //        foreach (var subitem in item)
            //        {
            //            //Console.Write(subitem.docNum);
            //            //Console.Write("\n");
            //            if (!judgedDocNum.Contains(subitem.docNum))
            //            {
            //                judgedDocNum.Add(subitem.docNum);
            //            }
            //        }
            //    }
            //    for (int i = 0; i < judgedDocNum.Count(); i++)
            //    {
            //        /*var item = Program.ListDocuments.SingleOrDefault(x => x.No == judgedDocNum[i]);
            //        if (item != null)
            //        {
            //            Program.ListDocuments.Remove(item);
            //        }*/
            //        //document title and content jadi null
            //        Program.ListDocuments.ElementAt(Int32.Parse(judgedDocNum[i]) - 1).Title = "";
            //        string[] tempContent = new string[1];
            //        tempContent[0] = "";
            //        Program.ListDocuments.ElementAt(Int32.Parse(judgedDocNum[i]) - 1).Content = tempContent;
            //    }
            //}
            Program.createInvertedFileFromListDocuments();

            if (Program.useQueryExpansion == 1)
            {
                QueryExpansion.doQueryExpansion();
            }
            RelevanceFeedback.reWeightingQuery();
            RelevanceFeedback.reCalculateSimilarity(-1);
            Program.nRelevantRetrieved(Program.allResults, Program.relevantJudgements); //pake relevantJudgement yang baru! -> udah di hapus pas assignFeedback

            

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
                for (int a = 0; a <= Program.lQueryWeightOld.ElementAt(i).Count() - 1; a++)
                {
                    listBoxResultInteractive.Items.Add(Program.lQueryWeightOld.ElementAt(i).ElementAt(a).term + " " + Program.lQueryWeightOld.ElementAt(i).ElementAt(a).weight);
                }
                if (Program.lQueryWeightNew.ElementAt(i).Count() != 0)
                {
                    line = Program.lQueryWeightNew.ElementAt(i).ElementAt(0).term;
                    for (int b = 1; b <= Program.lQueryWeightNew.ElementAt(i).Count() - 1; b++)
                    {
                        line = line + " ";
                        line = line + Program.lQueryWeightNew.ElementAt(i).ElementAt(b).term;
                    }
                    listBoxResultInteractive.Items.Add(line);
                }
                for (int c = 0; c <= Program.lQueryWeightNew.ElementAt(i).Count() - 1; c++)
                {
                    listBoxResultInteractive.Items.Add(Program.lQueryWeightNew.ElementAt(i).ElementAt(c).term + " " + Program.lQueryWeightNew.ElementAt(i).ElementAt(c).weight);
                }
                listBoxResultInteractive.Items.Add("Recall = " + Program.calculateRecall(i));
                listBoxResultInteractive.Items.Add("Precision = " + Program.calculatePrecision(i));
                listBoxResultInteractive.Items.Add("Non-Interpolated Average Precision = " + Program.calculateNIAP(i));
                meanRecall = meanRecall + Program.calculateRecall(i);
                meanPrecision = meanPrecision+ Program.calculatePrecision(i);
                meanNIAP = meanNIAP + Program.calculateNIAP(i);
                
                for (int j = 0; j < Program.allResults.ElementAt(i).Count(); j++)
                {
                    line = j + 1 + ". ";
                    line = line + ("similarity = ") + Program.allResults[i][j].val + ("-- ");
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

        private void buttonSecondRetrieval_Click(object sender, EventArgs e) // interactive mode
        {
            Program.relFeedback.Clear();
            Program.relFeedback.Add(Program.dvList);

            //print query baru + weight
            /*
            foreach (var item in Program.lQueryWeightNew)
            {
                foreach (var subitem in item)
                {
                    Console.Write(subitem.term);
                    Console.Write("---");
                    Console.Write(subitem.weight);
                    Console.Write("\n");
                }
            }*/


            // if user choose "different doc" option, update listDocument. remove judged document (relFeedback) and update reljudgement(for experiment only)
            if (Program.secondDocCollection.Equals("diff"))
            {
                int count = Program.relFeedback.Count(); //menghitung jumlah feedback yang diberikan user
                List<string> judgedDocNum = new List<string>(); //list of judged documents number
                foreach (var item in Program.relFeedback)
                {
                    foreach (var subitem in item)
                    {
                        //Console.Write(subitem.docNum);
                        //Console.Write("\n");
                        if (!judgedDocNum.Contains(subitem.docNum))
                        {
                            judgedDocNum.Add(subitem.docNum);
                        }
                    }
                }
                for (int i = 0; i < judgedDocNum.Count(); i++)
                {
                    /*var item = Program.ListDocuments.SingleOrDefault(x => x.No == judgedDocNum[i]);
                    if (item != null)
                    {
                        Program.ListDocuments.Remove(item);
                    }*/
                    //document title and content jadi null
                    Program.ListDocuments.ElementAt(Int32.Parse(judgedDocNum[i]) - 1).Title = " ";
                    string[] tempContent = new string[1];
                    tempContent[0] = " ";
                    Program.ListDocuments.ElementAt(Int32.Parse(judgedDocNum[i]) - 1).Content = tempContent;
                }
            }
            Program.createInvertedFileFromListDocuments();

            //do retrieval as first retrieval
            
            //Queries expandedQuery = new Queries();
            //expandedQuery.query[0] = "library"; //isi pake expanded 
            //Program.findResultQueries(expandedQuery, -1);
            if (Program.useQueryExpansion == 1)
            {
                QueryExpansion.doQueryExpansion();
            }
            RelevanceFeedback.reWeightingQuery();
            RelevanceFeedback.reCalculateSimilarity(-1);
            
            //show result in the form
            listBoxResultInteractive.Items.Clear();
            string line;
            int nd, numerator;
            numerator = 1;

            for (int i = 0; i < Program.allResults.Count(); i++)
            {
                line = Program.lQueryWeightOld.ElementAt(i).ElementAt(0).term;
                for (int k=1; k<= Program.lQueryWeightOld.ElementAt(i).Count()-1; k++)
                {
                    line = line + " ";
                    line = line + Program.lQueryWeightOld.ElementAt(i).ElementAt(k).term;
                }
                listBoxResultInteractive.Items.Add(line);
                for (int l = 0; l <= Program.lQueryWeightOld.ElementAt(i).Count() - 1; l++)
                {
                    listBoxResultInteractive.Items.Add(Program.lQueryWeightOld.ElementAt(i).ElementAt(l).term + " " + Program.lQueryWeightOld.ElementAt(i).ElementAt(l).weight);
                }
                line = Program.lQueryWeightNew.ElementAt(i).ElementAt(0).term;
                for (int k = 1; k <= Program.lQueryWeightNew.ElementAt(i).Count() - 1; k++)
                {
                    line = line + " ";
                    line = line + Program.lQueryWeightNew.ElementAt(i).ElementAt(k).term;
                }
                listBoxResultInteractive.Items.Add(line);
                for (int l = 0; l <= Program.lQueryWeightNew.ElementAt(i).Count() - 1; l++)
                {
                    listBoxResultInteractive.Items.Add(Program.lQueryWeightNew.ElementAt(i).ElementAt(l).term + " " + Program.lQueryWeightNew.ElementAt(i).ElementAt(l).weight);
                }
                for (int j = 0; j < Program.allResults.ElementAt(i).Count(); j++)
                {                    
                    line = numerator + ". ";
                    line = line + ("similarity = ") + Program.allResults[i][j].val + ("-- ");
                    nd = Int32.Parse(Program.allResults[i][j].docNum) - 1;
                    line = line + ("((") + Program.ListDocuments[nd].No + ("))");
                    line = line + (" ---- ");
                    //Console.WriteLine("nd = " + nd);
                    line = line + Program.ListDocuments[nd].Title;
                    //Console.WriteLine("ini gilaaa : " + Program.ListDocuments.ElementAt(nd).Title);
                    //line = line + Program.dTitle_NumDoc.FirstOrDefault(x => x.Value == nd).Key;
                    if (!Program.ListDocuments[nd].Title.Equals(" "))
                    {
                        listBoxResultInteractive.Items.Add(line);
                        numerator++;
                    }
                }
            }


                //for (int i = 0; i < Program.qs.nQuery(); i++) //foreach query in test collection
                //{
                    //tambahin foreach relevan feedback
                    //Console.WriteLine("jumlah feedback : " + Program.relFeedback.Count());
                        
                        
                        //foreach (var item in Program.relFeedback)
                        //{
                        //    foreach (var subitem in item)
                        //    {
                        //        Console.Write(subitem.docNum);
                        //        Console.Write(" ... ");
                        //        Console.Write(subitem.val);
                        //        Console.Write("\n");
                        //        if(Program.relevantJudgementsHash.ElementAt(0).ContainsKey(subitem.docNum)) //remove relevant document from qrels)
                        //        {
                        //            Program.relevantJudgementsHash.ElementAt(0).Remove("46"); //remove relevant document from qrels
                        //        }
                        //    }
                        //}
                    //Program.relevantJudgementsHash.ElementAt(0).Remove("46"); //remove relevant document from qrels
                //}
            
            // print relevant judgement hashtable to console
            //Console.WriteLine("ini rel judgement yang hash kedua");

            //for (int i = 0; i < Program.relevantJudgementsHash.Count(); i++)
            //{
            //    for (int j = 0; j < Program.relevantJudgementsHash.ElementAt(i).Count(); j++)
            //    {
            //        Console.Write(Program.relevantJudgementsHash.ElementAt(i).ElementAt(j).Key);
            //        Console.Write("-");
            //        Console.Write(Program.relevantJudgementsHash.ElementAt(i).ElementAt(j).Value);
            //        Console.Write(" ");
            //    }
            //    Console.Write("\n");
            //}

            // yang diatas tuh buat yang experiment. yang interactive ga usah update qrels
        }
    }
}
