namespace PetrMacek.ResultsImport
{
    partial class ImportForm
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
            this.components = new System.ComponentModel.Container();
            this.btnImport = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTradesCount = new System.Windows.Forms.Label();
            this.rdPoints = new System.Windows.Forms.RadioButton();
            this.rdPercent = new System.Windows.Forms.RadioButton();
            this.rdCurrency = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbLocaleCz = new System.Windows.Forms.RadioButton();
            this.rbLocaleUs = new System.Windows.Forms.RadioButton();
            this.lblDelimiter = new System.Windows.Forms.Label();
            this.tbCsvDelimiter = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlOutputfile = new System.Windows.Forms.Panel();
            this.btnOpenJournal = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOutputFilePath = new System.Windows.Forms.TextBox();
            this.rbAppend = new System.Windows.Forms.RadioButton();
            this.rbNewFile = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbHandlingDiscretionary = new System.Windows.Forms.RadioButton();
            this.rbHandlingAuto = new System.Windows.Forms.RadioButton();
            this.tipDiscretional = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlOutputfile.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(271, 418);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 25);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import!";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // openFile
            // 
            this.openFile.FileOk += new System.ComponentModel.CancelEventHandler(this.openFile_FileOk);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Location = new System.Drawing.Point(190, 46);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(138, 24);
            this.btnFileOpen.TabIndex = 1;
            this.btnFileOpen.Text = "Load backtest results";
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trades file:";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Location = new System.Drawing.Point(94, 19);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(234, 20);
            this.tbFilePath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Loaded trades:";
            // 
            // lblTradesCount
            // 
            this.lblTradesCount.AutoSize = true;
            this.lblTradesCount.Location = new System.Drawing.Point(98, 74);
            this.lblTradesCount.Name = "lblTradesCount";
            this.lblTradesCount.Size = new System.Drawing.Size(0, 13);
            this.lblTradesCount.TabIndex = 5;
            // 
            // rdPoints
            // 
            this.rdPoints.AutoSize = true;
            this.rdPoints.Checked = true;
            this.rdPoints.Location = new System.Drawing.Point(17, 17);
            this.rdPoints.Name = "rdPoints";
            this.rdPoints.Size = new System.Drawing.Size(54, 17);
            this.rdPoints.TabIndex = 6;
            this.rdPoints.TabStop = true;
            this.rdPoints.Text = "Points";
            this.rdPoints.UseVisualStyleBackColor = true;
            this.rdPoints.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdPercent
            // 
            this.rdPercent.AutoSize = true;
            this.rdPercent.Enabled = false;
            this.rdPercent.Location = new System.Drawing.Point(17, 40);
            this.rdPercent.Name = "rdPercent";
            this.rdPercent.Size = new System.Drawing.Size(80, 17);
            this.rdPercent.TabIndex = 7;
            this.rdPercent.Text = "Percentage";
            this.rdPercent.UseVisualStyleBackColor = true;
            this.rdPercent.CheckedChanged += new System.EventHandler(this.rdPercent_CheckedChanged);
            // 
            // rdCurrency
            // 
            this.rdCurrency.AutoSize = true;
            this.rdCurrency.Location = new System.Drawing.Point(17, 63);
            this.rdCurrency.Name = "rdCurrency";
            this.rdCurrency.Size = new System.Drawing.Size(67, 17);
            this.rdCurrency.TabIndex = 8;
            this.rdCurrency.Text = "Currency";
            this.rdCurrency.UseVisualStyleBackColor = true;
            this.rdCurrency.CheckedChanged += new System.EventHandler(this.rdCurrency_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdPercent);
            this.groupBox1.Controls.Add(this.rdCurrency);
            this.groupBox1.Controls.Add(this.rdPoints);
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 88);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CSV data units";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbLocaleCz);
            this.groupBox2.Controls.Add(this.rbLocaleUs);
            this.groupBox2.Location = new System.Drawing.Point(189, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CSV file locale";
            // 
            // rbLocaleCz
            // 
            this.rbLocaleCz.AutoSize = true;
            this.rbLocaleCz.Location = new System.Drawing.Point(13, 40);
            this.rbLocaleCz.Name = "rbLocaleCz";
            this.rbLocaleCz.Size = new System.Drawing.Size(56, 17);
            this.rbLocaleCz.TabIndex = 12;
            this.rbLocaleCz.Text = "cs_CZ";
            this.rbLocaleCz.UseVisualStyleBackColor = true;
            this.rbLocaleCz.CheckedChanged += new System.EventHandler(this.rbLocaleCz_CheckedChanged);
            // 
            // rbLocaleUs
            // 
            this.rbLocaleUs.AutoSize = true;
            this.rbLocaleUs.Checked = true;
            this.rbLocaleUs.Location = new System.Drawing.Point(13, 17);
            this.rbLocaleUs.Name = "rbLocaleUs";
            this.rbLocaleUs.Size = new System.Drawing.Size(58, 17);
            this.rbLocaleUs.TabIndex = 11;
            this.rbLocaleUs.TabStop = true;
            this.rbLocaleUs.Text = "en_US";
            this.rbLocaleUs.UseVisualStyleBackColor = true;
            this.rbLocaleUs.CheckedChanged += new System.EventHandler(this.rbLocaleUs_CheckedChanged);
            // 
            // lblDelimiter
            // 
            this.lblDelimiter.AutoSize = true;
            this.lblDelimiter.Location = new System.Drawing.Point(14, 49);
            this.lblDelimiter.Name = "lblDelimiter";
            this.lblDelimiter.Size = new System.Drawing.Size(72, 13);
            this.lblDelimiter.TabIndex = 11;
            this.lblDelimiter.Text = "CSV delimiter:";
            // 
            // tbCsvDelimiter
            // 
            this.tbCsvDelimiter.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCsvDelimiter.Location = new System.Drawing.Point(94, 46);
            this.tbCsvDelimiter.Name = "tbCsvDelimiter";
            this.tbCsvDelimiter.Size = new System.Drawing.Size(39, 21);
            this.tbCsvDelimiter.TabIndex = 12;
            this.tbCsvDelimiter.Text = ",";
            this.tbCsvDelimiter.TextChanged += new System.EventHandler(this.tbCsvDelimiter_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFileOpen);
            this.groupBox3.Controls.Add(this.tbCsvDelimiter);
            this.groupBox3.Controls.Add(this.tbFilePath);
            this.groupBox3.Controls.Add(this.lblDelimiter);
            this.groupBox3.Controls.Add(this.lblTradesCount);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 101);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input file";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlOutputfile);
            this.groupBox4.Controls.Add(this.rbAppend);
            this.groupBox4.Controls.Add(this.rbNewFile);
            this.groupBox4.Location = new System.Drawing.Point(12, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 112);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output file";
            // 
            // pnlOutputfile
            // 
            this.pnlOutputfile.Controls.Add(this.btnOpenJournal);
            this.pnlOutputfile.Controls.Add(this.label3);
            this.pnlOutputfile.Controls.Add(this.tbOutputFilePath);
            this.pnlOutputfile.Location = new System.Drawing.Point(7, 43);
            this.pnlOutputfile.Name = "pnlOutputfile";
            this.pnlOutputfile.Size = new System.Drawing.Size(337, 63);
            this.pnlOutputfile.TabIndex = 2;
            // 
            // btnOpenJournal
            // 
            this.btnOpenJournal.Location = new System.Drawing.Point(183, 26);
            this.btnOpenJournal.Name = "btnOpenJournal";
            this.btnOpenJournal.Size = new System.Drawing.Size(138, 24);
            this.btnOpenJournal.TabIndex = 13;
            this.btnOpenJournal.Text = "Open existing journal";
            this.btnOpenJournal.UseVisualStyleBackColor = true;
            this.btnOpenJournal.Click += new System.EventHandler(this.btnOpenJournal_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Existing journal:";
            // 
            // tbOutputFilePath
            // 
            this.tbOutputFilePath.Location = new System.Drawing.Point(87, 3);
            this.tbOutputFilePath.Name = "tbOutputFilePath";
            this.tbOutputFilePath.Size = new System.Drawing.Size(234, 20);
            this.tbOutputFilePath.TabIndex = 4;
            // 
            // rbAppend
            // 
            this.rbAppend.AutoSize = true;
            this.rbAppend.Location = new System.Drawing.Point(190, 20);
            this.rbAppend.Name = "rbAppend";
            this.rbAppend.Size = new System.Drawing.Size(112, 17);
            this.rbAppend.TabIndex = 1;
            this.rbAppend.Text = "Append to existing";
            this.rbAppend.UseVisualStyleBackColor = true;
            this.rbAppend.CheckedChanged += new System.EventHandler(this.rbAppend_CheckedChanged);
            // 
            // rbNewFile
            // 
            this.rbNewFile.AutoSize = true;
            this.rbNewFile.Checked = true;
            this.rbNewFile.Location = new System.Drawing.Point(17, 19);
            this.rbNewFile.Name = "rbNewFile";
            this.rbNewFile.Size = new System.Drawing.Size(63, 17);
            this.rbNewFile.TabIndex = 0;
            this.rbNewFile.TabStop = true;
            this.rbNewFile.Text = "New file";
            this.rbNewFile.UseVisualStyleBackColor = true;
            this.rbNewFile.CheckedChanged += new System.EventHandler(this.rbNewFile_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(373, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbHandlingAuto);
            this.groupBox5.Controls.Add(this.rbHandlingDiscretionary);
            this.groupBox5.Location = new System.Drawing.Point(13, 230);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 64);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Trades handling";
            // 
            // rbHandlingDiscretionary
            // 
            this.rbHandlingDiscretionary.AutoSize = true;
            this.rbHandlingDiscretionary.Checked = true;
            this.rbHandlingDiscretionary.Location = new System.Drawing.Point(16, 20);
            this.rbHandlingDiscretionary.Name = "rbHandlingDiscretionary";
            this.rbHandlingDiscretionary.Size = new System.Drawing.Size(148, 17);
            this.rbHandlingDiscretionary.TabIndex = 0;
            this.rbHandlingDiscretionary.TabStop = true;
            this.rbHandlingDiscretionary.Text = "Discretional trading results";
            this.rbHandlingDiscretionary.UseVisualStyleBackColor = true;
            this.rbHandlingDiscretionary.CheckedChanged += new System.EventHandler(this.rbHandlingDiscretionary_CheckedChanged);
            // 
            // rbHandlingAuto
            // 
            this.rbHandlingAuto.AutoSize = true;
            this.rbHandlingAuto.Location = new System.Drawing.Point(189, 20);
            this.rbHandlingAuto.Name = "rbHandlingAuto";
            this.rbHandlingAuto.Size = new System.Drawing.Size(149, 17);
            this.rbHandlingAuto.TabIndex = 1;
            this.rbHandlingAuto.Text = "Automated strategy results";
            this.rbHandlingAuto.UseVisualStyleBackColor = true;
            this.rbHandlingAuto.CheckedChanged += new System.EventHandler(this.rbHandlingAuto_CheckedChanged);
             // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 454);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImportForm";
            this.Text = "Import trades to excel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.pnlOutputfile.ResumeLayout(false);
            this.pnlOutputfile.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnFileOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTradesCount;
        private System.Windows.Forms.RadioButton rdPoints;
        private System.Windows.Forms.RadioButton rdPercent;
        private System.Windows.Forms.RadioButton rdCurrency;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbLocaleCz;
        private System.Windows.Forms.RadioButton rbLocaleUs;
        private System.Windows.Forms.Label lblDelimiter;
        private System.Windows.Forms.TextBox tbCsvDelimiter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbAppend;
        private System.Windows.Forms.RadioButton rbNewFile;
        private System.Windows.Forms.Panel pnlOutputfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOutputFilePath;
        private System.Windows.Forms.Button btnOpenJournal;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbHandlingAuto;
        private System.Windows.Forms.RadioButton rbHandlingDiscretionary;
        private System.Windows.Forms.ToolTip tipDiscretional;
    }
}

