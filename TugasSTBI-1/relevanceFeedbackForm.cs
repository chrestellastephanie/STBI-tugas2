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
    public partial class relevanceFeedbackForm : Form
    {
        int isRelevant = 0;
        public relevanceFeedbackForm()
        {
            InitializeComponent();
        }

        public void setTitle(string ttl)
        {
            documentTitle.Text = ttl;
        }
        private void buttonSaveRelevance_Click(object sender, EventArgs e)
        {
            if (checkBoxRelevance.Checked)
            {
                isRelevant = 1;
            }
            //Program.dvList = new List<Docvalue>();
            string titleRaw = documentTitle.Text;
            int pos = titleRaw.IndexOf(" ");
            titleRaw = titleRaw.Substring(pos+1); //ambil (<no dok>) - judul
            string noDoc = Between(titleRaw, "((", "))");
            string[] tempTitle = titleRaw.Split(new string[] { " ---- " }, StringSplitOptions.None); //ilangin no dokumen. 
            titleRaw = tempTitle[1];
            titleRaw = titleRaw + "|||" + noDoc;
            Console.WriteLine(titleRaw);
            string numDoc = Program.dTitle_NumDoc[titleRaw].ToString();
            Program.dvList.Add(new Docvalue(numDoc, isRelevant));
            Program.relFeedback.Add(Program.dvList);
            /*foreach (var item in Program.dvList)
            {
                Console.Write(item.docNum);
                Console.Write(" -- ");
                Console.Write(item.val);
                Console.Write("\n");
            }
            Console.Write("--------------------- \n");*/
            this.Close();
        }


        /// <summary>
        /// Reference: http://www.dotnetperls.com/between-before-after
        /// get document Author and Title
        /// </summary>
        public string Between(string value, string a, string b)
        {
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
        }
    }
}
