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
            setValueCode();
            Program.mainProgram(docDirectory, queryDirectory, relevanceDirectory, stopWordDirectory);
            this.Hide();
            RetrieveForm retForm = new RetrieveForm();
            retForm.Show();
        }

        private void setValueCode()
        {
            Program.tfDocCode = getTfDocRadioButtonValue();
            Program.idfDocCode = getIdfDocRadioButtonValue();
            Program.normDocCode = getNormDocRadioButtonValue();

            Program.tfQueryCode = getTfQueryRadioButtonValue();
            Program.idfQueryCode = getIdfQueryRadioButtonValue();
            Program.normQueryCode = getNormQueryRadioButtonValue();
        }

        private int getTfDocRadioButtonValue()
        {
            int value = 0;
            if(radioButtonRawTfDoc.Checked == true)
            {
                value = 1;
            }
            else if(radioButtonLogTfDoc.Checked == true)
            {
                value = 2;
            }
            else if(radioButtonBinaryTfDoc.Checked == true)
            {
                value = 3;
            }
            else if(radioButtonAugmentedTfDoc.Checked == true)
            {
                value = 4;
            }

            return value;
        }

        private int getTfQueryRadioButtonValue()
        {
            int value = 0;
            if (radioButtonRawTfQuery.Checked == true)
            {
                value = 1;
            }
            else if (radioButtonLogTfQuery.Checked == true)
            {
                value = 2;
            }
            else if (radioButtonBinaryTfQuery.Checked == true)
            {
                value = 3;
            }
            else if (radioButtonAugmentedTfQuery.Checked == true)
            {
                value = 4;
            }

            return value;
        }

        private int getIdfDocRadioButtonValue()
        {
            int value = 0;
            if (radioButtonIdfDoc.Checked == true)
            {
                value = 1;
            }

            return value;
        }

        private int getIdfQueryRadioButtonValue()
        {
            int value = 0;
            if (radioButtonIdfQuery.Checked == true)
            {
                value = 1;
            }

            return value;
        }

        private int getNormDocRadioButtonValue()
        {
            int value = 0;
            if (radioButtonNormDoc.Checked == true)
            {
                value = 1;
            }

            return value;
        }

        private int getNormQueryRadioButtonValue()
        {
            int value = 0;
            if (radioButtonNormQuery.Checked == true)
            {
                value = 1;
            }

            return value;
        }
    }
}
