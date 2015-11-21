namespace TugasSTBI_1
{
    partial class relevanceFeedbackForm
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
            this.documentTitle = new System.Windows.Forms.Label();
            this.buttonSaveRelevance = new System.Windows.Forms.Button();
            this.checkBoxRelevance = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // documentTitle
            // 
            this.documentTitle.AutoSize = true;
            this.documentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentTitle.Location = new System.Drawing.Point(12, 47);
            this.documentTitle.Name = "documentTitle";
            this.documentTitle.Size = new System.Drawing.Size(116, 20);
            this.documentTitle.TabIndex = 2;
            this.documentTitle.Text = "Document Title";
            // 
            // buttonSaveRelevance
            // 
            this.buttonSaveRelevance.Location = new System.Drawing.Point(703, 177);
            this.buttonSaveRelevance.Name = "buttonSaveRelevance";
            this.buttonSaveRelevance.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveRelevance.TabIndex = 4;
            this.buttonSaveRelevance.Text = "OK";
            this.buttonSaveRelevance.UseVisualStyleBackColor = true;
            this.buttonSaveRelevance.Click += new System.EventHandler(this.buttonSaveRelevance_Click);
            // 
            // checkBoxRelevance
            // 
            this.checkBoxRelevance.AutoSize = true;
            this.checkBoxRelevance.Location = new System.Drawing.Point(16, 12);
            this.checkBoxRelevance.Name = "checkBoxRelevance";
            this.checkBoxRelevance.Size = new System.Drawing.Size(110, 17);
            this.checkBoxRelevance.TabIndex = 6;
            this.checkBoxRelevance.Text = "Dokumen relevan";
            this.checkBoxRelevance.UseVisualStyleBackColor = true;
            // 
            // relevanceFeedbackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 207);
            this.Controls.Add(this.checkBoxRelevance);
            this.Controls.Add(this.buttonSaveRelevance);
            this.Controls.Add(this.documentTitle);
            this.Name = "relevanceFeedbackForm";
            this.Text = "relevanceFeedbackForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label documentTitle;
        private System.Windows.Forms.Button buttonSaveRelevance;
        private System.Windows.Forms.CheckBox checkBoxRelevance;
    }
}