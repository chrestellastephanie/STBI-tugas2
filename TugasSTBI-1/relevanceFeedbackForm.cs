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
        }
    }
}
