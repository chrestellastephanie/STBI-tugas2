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
            titleRaw = titleRaw.Substring(pos+1);
            //Console.WriteLine("lala : " + pos + " -> " + titleRaw);
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
    }
}
