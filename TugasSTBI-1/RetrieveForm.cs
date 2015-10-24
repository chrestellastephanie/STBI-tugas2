﻿using System;
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
        }

        private void buttonInteractiveSearch_Click(object sender, EventArgs e)
        {
            Program.qs.query = textBoxInteractiveQuery.Text.Split(' ');
            Program.findResultQueries();
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
                    line = line + ("(") + Program.ListDocuments[nd].No + (")");
                    line = line + (" - ");
                    line = line + Program.ListDocuments[nd].Title;
                    listBoxResultInteractive.Items.Add(line);
                }
            }
        }
    }
}