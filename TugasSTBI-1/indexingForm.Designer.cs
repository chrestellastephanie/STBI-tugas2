namespace TugasSTBI_1
{
    partial class IndexingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonChooseQuery = new System.Windows.Forms.Button();
            this.buttonChooseRel = new System.Windows.Forms.Button();
            this.buttonChooseStopw = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoTfDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonAugmentedTfDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryTfDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonLogTfDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonRawTfDoc = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoIdfDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonIdfDoc = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoNormDoc = new System.Windows.Forms.RadioButton();
            this.radioButtonNormDoc = new System.Windows.Forms.RadioButton();
            this.buttonCreateInvertedFile = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Tf = new System.Windows.Forms.GroupBox();
            this.radioButtonNoTfQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonAugmentedTfQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonBinaryTfQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonLogTfQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonRawTfQuery = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoIdfQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonIdfQuery = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoNormQuery = new System.Windows.Forms.RadioButton();
            this.radioButtonNormQuery = new System.Windows.Forms.RadioButton();
            this.checkBoxStemming = new System.Windows.Forms.CheckBox();
            this.textBoxDocPath = new System.Windows.Forms.TextBox();
            this.textBoxQueryPath = new System.Windows.Forms.TextBox();
            this.textBoxSWPath = new System.Windows.Forms.TextBox();
            this.textBoxRelPath = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Tf.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dokumen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Query";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Relevant Judgement";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop Words";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonChooseQuery
            // 
            this.buttonChooseQuery.Location = new System.Drawing.Point(283, 49);
            this.buttonChooseQuery.Name = "buttonChooseQuery";
            this.buttonChooseQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseQuery.TabIndex = 5;
            this.buttonChooseQuery.Text = "Choose";
            this.buttonChooseQuery.UseVisualStyleBackColor = true;
            this.buttonChooseQuery.Click += new System.EventHandler(this.buttonChooseQuery_Click);
            // 
            // buttonChooseRel
            // 
            this.buttonChooseRel.Location = new System.Drawing.Point(283, 77);
            this.buttonChooseRel.Name = "buttonChooseRel";
            this.buttonChooseRel.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseRel.TabIndex = 6;
            this.buttonChooseRel.Text = "Choose";
            this.buttonChooseRel.UseVisualStyleBackColor = true;
            this.buttonChooseRel.Click += new System.EventHandler(this.buttonChooseRel_Click);
            // 
            // buttonChooseStopw
            // 
            this.buttonChooseStopw.Location = new System.Drawing.Point(283, 106);
            this.buttonChooseStopw.Name = "buttonChooseStopw";
            this.buttonChooseStopw.Size = new System.Drawing.Size(75, 23);
            this.buttonChooseStopw.TabIndex = 7;
            this.buttonChooseStopw.Text = "Choose";
            this.buttonChooseStopw.UseVisualStyleBackColor = true;
            this.buttonChooseStopw.Click += new System.EventHandler(this.buttonChooseStopw_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonNoTfDoc);
            this.groupBox1.Controls.Add(this.radioButtonAugmentedTfDoc);
            this.groupBox1.Controls.Add(this.radioButtonBinaryTfDoc);
            this.groupBox1.Controls.Add(this.radioButtonLogTfDoc);
            this.groupBox1.Controls.Add(this.radioButtonRawTfDoc);
            this.groupBox1.Location = new System.Drawing.Point(12, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 141);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tf";
            // 
            // radioButtonNoTfDoc
            // 
            this.radioButtonNoTfDoc.AutoSize = true;
            this.radioButtonNoTfDoc.Location = new System.Drawing.Point(18, 111);
            this.radioButtonNoTfDoc.Name = "radioButtonNoTfDoc";
            this.radioButtonNoTfDoc.Size = new System.Drawing.Size(52, 17);
            this.radioButtonNoTfDoc.TabIndex = 4;
            this.radioButtonNoTfDoc.TabStop = true;
            this.radioButtonNoTfDoc.Text = "No Tf";
            this.radioButtonNoTfDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonAugmentedTfDoc
            // 
            this.radioButtonAugmentedTfDoc.AutoSize = true;
            this.radioButtonAugmentedTfDoc.Location = new System.Drawing.Point(18, 88);
            this.radioButtonAugmentedTfDoc.Name = "radioButtonAugmentedTfDoc";
            this.radioButtonAugmentedTfDoc.Size = new System.Drawing.Size(92, 17);
            this.radioButtonAugmentedTfDoc.TabIndex = 3;
            this.radioButtonAugmentedTfDoc.TabStop = true;
            this.radioButtonAugmentedTfDoc.Text = "Augmented Tf";
            this.radioButtonAugmentedTfDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryTfDoc
            // 
            this.radioButtonBinaryTfDoc.AutoSize = true;
            this.radioButtonBinaryTfDoc.Location = new System.Drawing.Point(18, 65);
            this.radioButtonBinaryTfDoc.Name = "radioButtonBinaryTfDoc";
            this.radioButtonBinaryTfDoc.Size = new System.Drawing.Size(67, 17);
            this.radioButtonBinaryTfDoc.TabIndex = 2;
            this.radioButtonBinaryTfDoc.TabStop = true;
            this.radioButtonBinaryTfDoc.Text = "Binary Tf";
            this.radioButtonBinaryTfDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogTfDoc
            // 
            this.radioButtonLogTfDoc.AutoSize = true;
            this.radioButtonLogTfDoc.Location = new System.Drawing.Point(18, 42);
            this.radioButtonLogTfDoc.Name = "radioButtonLogTfDoc";
            this.radioButtonLogTfDoc.Size = new System.Drawing.Size(56, 17);
            this.radioButtonLogTfDoc.TabIndex = 1;
            this.radioButtonLogTfDoc.Text = "Log Tf";
            this.radioButtonLogTfDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonRawTfDoc
            // 
            this.radioButtonRawTfDoc.AutoSize = true;
            this.radioButtonRawTfDoc.Checked = true;
            this.radioButtonRawTfDoc.Location = new System.Drawing.Point(18, 19);
            this.radioButtonRawTfDoc.Name = "radioButtonRawTfDoc";
            this.radioButtonRawTfDoc.Size = new System.Drawing.Size(60, 17);
            this.radioButtonRawTfDoc.TabIndex = 0;
            this.radioButtonRawTfDoc.TabStop = true;
            this.radioButtonRawTfDoc.Text = "Raw Tf";
            this.radioButtonRawTfDoc.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonNoIdfDoc);
            this.groupBox2.Controls.Add(this.radioButtonIdfDoc);
            this.groupBox2.Location = new System.Drawing.Point(15, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 68);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "idf";
            // 
            // radioButtonNoIdfDoc
            // 
            this.radioButtonNoIdfDoc.AutoSize = true;
            this.radioButtonNoIdfDoc.Location = new System.Drawing.Point(6, 42);
            this.radioButtonNoIdfDoc.Name = "radioButtonNoIdfDoc";
            this.radioButtonNoIdfDoc.Size = new System.Drawing.Size(53, 17);
            this.radioButtonNoIdfDoc.TabIndex = 1;
            this.radioButtonNoIdfDoc.TabStop = true;
            this.radioButtonNoIdfDoc.Text = "No idf";
            this.radioButtonNoIdfDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonIdfDoc
            // 
            this.radioButtonIdfDoc.AutoSize = true;
            this.radioButtonIdfDoc.Checked = true;
            this.radioButtonIdfDoc.Location = new System.Drawing.Point(6, 19);
            this.radioButtonIdfDoc.Name = "radioButtonIdfDoc";
            this.radioButtonIdfDoc.Size = new System.Drawing.Size(37, 17);
            this.radioButtonIdfDoc.TabIndex = 0;
            this.radioButtonIdfDoc.TabStop = true;
            this.radioButtonIdfDoc.Text = "Idf";
            this.radioButtonIdfDoc.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButtonNoNormDoc);
            this.groupBox3.Controls.Add(this.radioButtonNormDoc);
            this.groupBox3.Location = new System.Drawing.Point(15, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 67);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Normalization";
            // 
            // radioButtonNoNormDoc
            // 
            this.radioButtonNoNormDoc.AutoSize = true;
            this.radioButtonNoNormDoc.Location = new System.Drawing.Point(6, 42);
            this.radioButtonNoNormDoc.Name = "radioButtonNoNormDoc";
            this.radioButtonNoNormDoc.Size = new System.Drawing.Size(103, 17);
            this.radioButtonNoNormDoc.TabIndex = 1;
            this.radioButtonNoNormDoc.TabStop = true;
            this.radioButtonNoNormDoc.Text = "No normalization";
            this.radioButtonNoNormDoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormDoc
            // 
            this.radioButtonNormDoc.AutoSize = true;
            this.radioButtonNormDoc.Checked = true;
            this.radioButtonNormDoc.Location = new System.Drawing.Point(6, 23);
            this.radioButtonNormDoc.Name = "radioButtonNormDoc";
            this.radioButtonNormDoc.Size = new System.Drawing.Size(88, 17);
            this.radioButtonNormDoc.TabIndex = 0;
            this.radioButtonNormDoc.TabStop = true;
            this.radioButtonNormDoc.Text = "Normalization";
            this.radioButtonNormDoc.UseVisualStyleBackColor = true;
            // 
            // buttonCreateInvertedFile
            // 
            this.buttonCreateInvertedFile.Location = new System.Drawing.Point(12, 522);
            this.buttonCreateInvertedFile.Name = "buttonCreateInvertedFile";
            this.buttonCreateInvertedFile.Size = new System.Drawing.Size(343, 23);
            this.buttonCreateInvertedFile.TabIndex = 13;
            this.buttonCreateInvertedFile.Text = "Create Inverted File";
            this.buttonCreateInvertedFile.UseVisualStyleBackColor = true;
            this.buttonCreateInvertedFile.Click += new System.EventHandler(this.buttonCreateInvertedFile_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Document";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(175, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Query";
            // 
            // Tf
            // 
            this.Tf.Controls.Add(this.radioButtonNoTfQuery);
            this.Tf.Controls.Add(this.radioButtonAugmentedTfQuery);
            this.Tf.Controls.Add(this.radioButtonBinaryTfQuery);
            this.Tf.Controls.Add(this.radioButtonLogTfQuery);
            this.Tf.Controls.Add(this.radioButtonRawTfQuery);
            this.Tf.Location = new System.Drawing.Point(180, 174);
            this.Tf.Name = "Tf";
            this.Tf.Size = new System.Drawing.Size(141, 137);
            this.Tf.TabIndex = 16;
            this.Tf.TabStop = false;
            this.Tf.Text = "Tf";
            // 
            // radioButtonNoTfQuery
            // 
            this.radioButtonNoTfQuery.AutoSize = true;
            this.radioButtonNoTfQuery.Location = new System.Drawing.Point(6, 112);
            this.radioButtonNoTfQuery.Name = "radioButtonNoTfQuery";
            this.radioButtonNoTfQuery.Size = new System.Drawing.Size(52, 17);
            this.radioButtonNoTfQuery.TabIndex = 4;
            this.radioButtonNoTfQuery.TabStop = true;
            this.radioButtonNoTfQuery.Text = "No Tf";
            this.radioButtonNoTfQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonAugmentedTfQuery
            // 
            this.radioButtonAugmentedTfQuery.AutoSize = true;
            this.radioButtonAugmentedTfQuery.Location = new System.Drawing.Point(6, 89);
            this.radioButtonAugmentedTfQuery.Name = "radioButtonAugmentedTfQuery";
            this.radioButtonAugmentedTfQuery.Size = new System.Drawing.Size(92, 17);
            this.radioButtonAugmentedTfQuery.TabIndex = 3;
            this.radioButtonAugmentedTfQuery.TabStop = true;
            this.radioButtonAugmentedTfQuery.Text = "Augmented Tf";
            this.radioButtonAugmentedTfQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinaryTfQuery
            // 
            this.radioButtonBinaryTfQuery.AutoSize = true;
            this.radioButtonBinaryTfQuery.Location = new System.Drawing.Point(6, 66);
            this.radioButtonBinaryTfQuery.Name = "radioButtonBinaryTfQuery";
            this.radioButtonBinaryTfQuery.Size = new System.Drawing.Size(67, 17);
            this.radioButtonBinaryTfQuery.TabIndex = 2;
            this.radioButtonBinaryTfQuery.TabStop = true;
            this.radioButtonBinaryTfQuery.Text = "Binary Tf";
            this.radioButtonBinaryTfQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogTfQuery
            // 
            this.radioButtonLogTfQuery.AutoSize = true;
            this.radioButtonLogTfQuery.Location = new System.Drawing.Point(6, 43);
            this.radioButtonLogTfQuery.Name = "radioButtonLogTfQuery";
            this.radioButtonLogTfQuery.Size = new System.Drawing.Size(56, 17);
            this.radioButtonLogTfQuery.TabIndex = 1;
            this.radioButtonLogTfQuery.TabStop = true;
            this.radioButtonLogTfQuery.Text = "Log Tf";
            this.radioButtonLogTfQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonRawTfQuery
            // 
            this.radioButtonRawTfQuery.AutoSize = true;
            this.radioButtonRawTfQuery.Checked = true;
            this.radioButtonRawTfQuery.Location = new System.Drawing.Point(6, 20);
            this.radioButtonRawTfQuery.Name = "radioButtonRawTfQuery";
            this.radioButtonRawTfQuery.Size = new System.Drawing.Size(60, 17);
            this.radioButtonRawTfQuery.TabIndex = 0;
            this.radioButtonRawTfQuery.TabStop = true;
            this.radioButtonRawTfQuery.Text = "Raw Tf";
            this.radioButtonRawTfQuery.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButtonNoIdfQuery);
            this.groupBox4.Controls.Add(this.radioButtonIdfQuery);
            this.groupBox4.Location = new System.Drawing.Point(178, 323);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(143, 67);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "idf";
            // 
            // radioButtonNoIdfQuery
            // 
            this.radioButtonNoIdfQuery.AutoSize = true;
            this.radioButtonNoIdfQuery.Location = new System.Drawing.Point(8, 41);
            this.radioButtonNoIdfQuery.Name = "radioButtonNoIdfQuery";
            this.radioButtonNoIdfQuery.Size = new System.Drawing.Size(53, 17);
            this.radioButtonNoIdfQuery.TabIndex = 1;
            this.radioButtonNoIdfQuery.TabStop = true;
            this.radioButtonNoIdfQuery.Text = "No idf";
            this.radioButtonNoIdfQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonIdfQuery
            // 
            this.radioButtonIdfQuery.AutoSize = true;
            this.radioButtonIdfQuery.Checked = true;
            this.radioButtonIdfQuery.Location = new System.Drawing.Point(8, 19);
            this.radioButtonIdfQuery.Name = "radioButtonIdfQuery";
            this.radioButtonIdfQuery.Size = new System.Drawing.Size(37, 17);
            this.radioButtonIdfQuery.TabIndex = 0;
            this.radioButtonIdfQuery.TabStop = true;
            this.radioButtonIdfQuery.Text = "Idf";
            this.radioButtonIdfQuery.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonNoNormQuery);
            this.groupBox5.Controls.Add(this.radioButtonNormQuery);
            this.groupBox5.Location = new System.Drawing.Point(178, 398);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(143, 65);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Normalization";
            // 
            // radioButtonNoNormQuery
            // 
            this.radioButtonNoNormQuery.AutoSize = true;
            this.radioButtonNoNormQuery.Location = new System.Drawing.Point(8, 40);
            this.radioButtonNoNormQuery.Name = "radioButtonNoNormQuery";
            this.radioButtonNoNormQuery.Size = new System.Drawing.Size(103, 17);
            this.radioButtonNoNormQuery.TabIndex = 1;
            this.radioButtonNoNormQuery.TabStop = true;
            this.radioButtonNoNormQuery.Text = "No normalization";
            this.radioButtonNoNormQuery.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormQuery
            // 
            this.radioButtonNormQuery.AutoSize = true;
            this.radioButtonNormQuery.Checked = true;
            this.radioButtonNormQuery.Location = new System.Drawing.Point(8, 19);
            this.radioButtonNormQuery.Name = "radioButtonNormQuery";
            this.radioButtonNormQuery.Size = new System.Drawing.Size(88, 17);
            this.radioButtonNormQuery.TabIndex = 0;
            this.radioButtonNormQuery.TabStop = true;
            this.radioButtonNormQuery.Text = "Normalization";
            this.radioButtonNormQuery.UseVisualStyleBackColor = true;
            // 
            // checkBoxStemming
            // 
            this.checkBoxStemming.AutoSize = true;
            this.checkBoxStemming.Checked = true;
            this.checkBoxStemming.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxStemming.Location = new System.Drawing.Point(15, 483);
            this.checkBoxStemming.Name = "checkBoxStemming";
            this.checkBoxStemming.Size = new System.Drawing.Size(72, 17);
            this.checkBoxStemming.TabIndex = 19;
            this.checkBoxStemming.Text = "Stemming";
            this.checkBoxStemming.UseVisualStyleBackColor = true;
            // 
            // textBoxDocPath
            // 
            this.textBoxDocPath.Location = new System.Drawing.Point(75, 22);
            this.textBoxDocPath.Name = "textBoxDocPath";
            this.textBoxDocPath.Size = new System.Drawing.Size(202, 20);
            this.textBoxDocPath.TabIndex = 20;
            this.textBoxDocPath.Text = "D:/ADI/adi.all";
            // 
            // textBoxQueryPath
            // 
            this.textBoxQueryPath.Location = new System.Drawing.Point(75, 49);
            this.textBoxQueryPath.Name = "textBoxQueryPath";
            this.textBoxQueryPath.Size = new System.Drawing.Size(202, 20);
            this.textBoxQueryPath.TabIndex = 21;
            this.textBoxQueryPath.Text = "D:/ADI/query.text";
            // 
            // textBoxSWPath
            // 
            this.textBoxSWPath.Location = new System.Drawing.Point(76, 108);
            this.textBoxSWPath.Name = "textBoxSWPath";
            this.textBoxSWPath.Size = new System.Drawing.Size(202, 20);
            this.textBoxSWPath.TabIndex = 22;
            this.textBoxSWPath.Text = "D:/stopwords.txt";
            // 
            // textBoxRelPath
            // 
            this.textBoxRelPath.Location = new System.Drawing.Point(115, 79);
            this.textBoxRelPath.Name = "textBoxRelPath";
            this.textBoxRelPath.Size = new System.Drawing.Size(161, 20);
            this.textBoxRelPath.TabIndex = 23;
            this.textBoxRelPath.Text = "D:/ADI/qrels.text";
            // 
            // IndexingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 557);
            this.Controls.Add(this.textBoxRelPath);
            this.Controls.Add(this.textBoxSWPath);
            this.Controls.Add(this.textBoxQueryPath);
            this.Controls.Add(this.textBoxDocPath);
            this.Controls.Add(this.checkBoxStemming);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Tf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCreateInvertedFile);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonChooseStopw);
            this.Controls.Add(this.buttonChooseRel);
            this.Controls.Add(this.buttonChooseQuery);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IndexingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "indexingForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Tf.ResumeLayout(false);
            this.Tf.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonChooseQuery;
        private System.Windows.Forms.Button buttonChooseRel;
        private System.Windows.Forms.Button buttonChooseStopw;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonNoTfDoc;
        private System.Windows.Forms.RadioButton radioButtonAugmentedTfDoc;
        private System.Windows.Forms.RadioButton radioButtonBinaryTfDoc;
        private System.Windows.Forms.RadioButton radioButtonLogTfDoc;
        private System.Windows.Forms.RadioButton radioButtonRawTfDoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonNoIdfDoc;
        private System.Windows.Forms.RadioButton radioButtonIdfDoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonNoNormDoc;
        private System.Windows.Forms.RadioButton radioButtonNormDoc;
        private System.Windows.Forms.Button buttonCreateInvertedFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Tf;
        private System.Windows.Forms.RadioButton radioButtonNoTfQuery;
        private System.Windows.Forms.RadioButton radioButtonAugmentedTfQuery;
        private System.Windows.Forms.RadioButton radioButtonBinaryTfQuery;
        private System.Windows.Forms.RadioButton radioButtonLogTfQuery;
        private System.Windows.Forms.RadioButton radioButtonRawTfQuery;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonNoIdfQuery;
        private System.Windows.Forms.RadioButton radioButtonIdfQuery;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButtonNoNormQuery;
        private System.Windows.Forms.RadioButton radioButtonNormQuery;
        private System.Windows.Forms.CheckBox checkBoxStemming;
        private System.Windows.Forms.TextBox textBoxDocPath;
        private System.Windows.Forms.TextBox textBoxQueryPath;
        private System.Windows.Forms.TextBox textBoxSWPath;
        private System.Windows.Forms.TextBox textBoxRelPath;

    }
}