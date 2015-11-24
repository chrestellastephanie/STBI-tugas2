namespace TugasSTBI_1
{
    partial class RetrieveForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxInteractiveQuery = new System.Windows.Forms.TextBox();
            this.buttonInteractiveSearch = new System.Windows.Forms.Button();
            this.listBoxResultInteractive = new System.Windows.Forms.ListBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonSecondRetrieval = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Experiment";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Interactive";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxInteractiveQuery
            // 
            this.textBoxInteractiveQuery.Location = new System.Drawing.Point(12, 54);
            this.textBoxInteractiveQuery.Name = "textBoxInteractiveQuery";
            this.textBoxInteractiveQuery.Size = new System.Drawing.Size(820, 20);
            this.textBoxInteractiveQuery.TabIndex = 2;
            this.textBoxInteractiveQuery.Visible = false;
            // 
            // buttonInteractiveSearch
            // 
            this.buttonInteractiveSearch.Location = new System.Drawing.Point(861, 51);
            this.buttonInteractiveSearch.Name = "buttonInteractiveSearch";
            this.buttonInteractiveSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonInteractiveSearch.TabIndex = 3;
            this.buttonInteractiveSearch.Text = "Search";
            this.buttonInteractiveSearch.UseVisualStyleBackColor = true;
            this.buttonInteractiveSearch.Visible = false;
            this.buttonInteractiveSearch.Click += new System.EventHandler(this.buttonInteractiveSearch_Click);
            // 
            // listBoxResultInteractive
            // 
            this.listBoxResultInteractive.FormattingEnabled = true;
            this.listBoxResultInteractive.Location = new System.Drawing.Point(12, 124);
            this.listBoxResultInteractive.Name = "listBoxResultInteractive";
            this.listBoxResultInteractive.Size = new System.Drawing.Size(820, 381);
            this.listBoxResultInteractive.TabIndex = 4;
            this.listBoxResultInteractive.Visible = false;
            this.listBoxResultInteractive.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxResultInteractive_MouseDoubleClick_1);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(12, 104);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(50, 13);
            this.labelResult.TabIndex = 5;
            this.labelResult.Text = "RESULT";
            this.labelResult.Visible = false;
            // 
            // buttonSecondRetrieval
            // 
            this.buttonSecondRetrieval.Location = new System.Drawing.Point(761, 12);
            this.buttonSecondRetrieval.Name = "buttonSecondRetrieval";
            this.buttonSecondRetrieval.Size = new System.Drawing.Size(175, 23);
            this.buttonSecondRetrieval.TabIndex = 6;
            this.buttonSecondRetrieval.Text = "Second Retrieval";
            this.buttonSecondRetrieval.UseVisualStyleBackColor = true;
            this.buttonSecondRetrieval.Visible = false;
            this.buttonSecondRetrieval.Click += new System.EventHandler(this.buttonSecondRetrieval_Click);
            // 
            // RetrieveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 524);
            this.Controls.Add(this.buttonSecondRetrieval);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.listBoxResultInteractive);
            this.Controls.Add(this.buttonInteractiveSearch);
            this.Controls.Add(this.textBoxInteractiveQuery);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "RetrieveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RetrieveForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RetrieveForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxInteractiveQuery;
        private System.Windows.Forms.Button buttonInteractiveSearch;
        private System.Windows.Forms.ListBox listBoxResultInteractive;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonSecondRetrieval;
    }
}