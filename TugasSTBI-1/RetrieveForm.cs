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
        }

        private void buttonInteractiveSearch_Click(object sender, EventArgs e)
        {
            Program.qs.query = textBoxInteractiveQuery.Text.Split(' ');
            Program.findResultQueries();
        }
    }
}
