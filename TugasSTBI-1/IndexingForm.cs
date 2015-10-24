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
    public partial class IndexingForm : Form
    {
        public static string docDirectory;
        public static string queryDirectory;
        public static string stopWordDirectory;
        public static string relevanceDirectory;
        public IndexingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult documentsDialog = openFileDialog1.ShowDialog();
            if (documentsDialog == DialogResult.OK)
            {
                docDirectory = openFileDialog1.FileName;
                textBoxDocPath.Text = docDirectory;
            }
        }

        private void buttonChooseQuery_Click(object sender, EventArgs e)
        {
            DialogResult documentsDialog = openFileDialog1.ShowDialog();
            if (documentsDialog == DialogResult.OK)
            {
                queryDirectory = openFileDialog1.FileName;
                textBoxQueryPath.Text = queryDirectory;
            }
        }

        private void buttonChooseRel_Click(object sender, EventArgs e)
        {
            DialogResult documentsDialog = openFileDialog1.ShowDialog();
            if (documentsDialog == DialogResult.OK)
            {
                relevanceDirectory = openFileDialog1.FileName;
                textBoxRelPath.Text = relevanceDirectory;
            }
        }

        private void buttonChooseStopw_Click(object sender, EventArgs e)
        {
            DialogResult documentsDialog = openFileDialog1.ShowDialog();
            if (documentsDialog == DialogResult.OK)
            {
                stopWordDirectory = openFileDialog1.FileName;
                textBoxSWPath.Text = stopWordDirectory;
            }
        }

        private void buttonCreateInvertedFile_Click(object sender, EventArgs e)
        {
            Program.mainProgram(docDirectory, queryDirectory, relevanceDirectory, stopWordDirectory);
            this.Hide();
            RetrieveForm retForm = new RetrieveForm();
            retForm.Show();
        }

    }
}
