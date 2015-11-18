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

            docDirectory = textBoxDocPath.Text;
            queryDirectory = textBoxQueryPath.Text;
            stopWordDirectory = textBoxSWPath.Text;
            relevanceDirectory = textBoxRelPath.Text;
        }

        private void button1_Click(object sender, EventArgs e) //choose document collection
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

            Program.stemCode = getStemCheckBoxValue();

            if (!string.IsNullOrWhiteSpace(nRetrieve1TextBox.Text)) //jika user mengisi jumlah dokumen yang diretrieve pertama kali
            {
                Program.nRetrieve1 = Int32.Parse(nRetrieve1TextBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(topNPseudoTextBox.Text)) //jika user mengisi top N untuk pseudo
            {
                Program.nPseudoRelevant = Int32.Parse(topNPseudoTextBox.Text);
            }
            Program.relevanceFeedbackMethod = getRelevanceFeedbackMethodValue();
            Program.useQueryExpansion = isUseQueryExpansion();
            Program.secondDocCollection = getSecondDocCollection();
            

            //Console.WriteLine("QE : " + Program.useQueryExpansion);
            
        }

        private string getRelevanceFeedbackMethodValue()
        {
            string method = "rochio";
            if (radioButtonRochio.Checked)
            {
                method = "rochio";
            }
            else if(radioButtonRegular.Checked)
            {
                method = "regular";
            }
            else if (radioButtonDecHi.Checked)
            {
                method = "dechi";
            }
            else if (radioButtonPseudo.Checked)
            {
                method = "pseudo";
            }
            return method;
        }

        private int isUseQueryExpansion()
        {
            if (radioButtonQEYes.Checked)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        private string getSecondDocCollection()
        {
            if (radioButtonSameDC.Checked)
            {
                return "same";
            }
            else
            {
                return "diff";
            }
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

        private int getStemCheckBoxValue()
        {
            int value = 0;
            if (checkBoxStemming.Checked == true)
            {
                value = 1;
            }

            return value;
        }
    }
}
