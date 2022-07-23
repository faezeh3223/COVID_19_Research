namespace COVID_19_Research
{
    partial class Form1
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
            this.csvBtn = new System.Windows.Forms.Button();
            this.jsonBtn = new System.Windows.Forms.Button();
            this.indexBtn = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.simpleSearchRadio = new System.Windows.Forms.RadioButton();
            this.advanceSearchRadio = new System.Windows.Forms.RadioButton();
            this.searchBtn = new System.Windows.Forms.Button();
            this.AdvanceGroup = new System.Windows.Forms.GroupBox();
            this.PageRankCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeWeight = new System.Windows.Forms.NumericUpDown();
            this.abstractWeight = new System.Windows.Forms.NumericUpDown();
            this.titleWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.abstractBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.AdvanceGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.abstractWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // csvBtn
            // 
            this.csvBtn.Enabled = false;
            this.csvBtn.Location = new System.Drawing.Point(674, 12);
            this.csvBtn.Name = "csvBtn";
            this.csvBtn.Size = new System.Drawing.Size(114, 38);
            this.csvBtn.TabIndex = 0;
            this.csvBtn.Text = "Open .CSV";
            this.csvBtn.UseVisualStyleBackColor = true;
            this.csvBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // jsonBtn
            // 
            this.jsonBtn.Enabled = false;
            this.jsonBtn.Location = new System.Drawing.Point(674, 56);
            this.jsonBtn.Name = "jsonBtn";
            this.jsonBtn.Size = new System.Drawing.Size(114, 38);
            this.jsonBtn.TabIndex = 1;
            this.jsonBtn.Text = "Open .JSON Files";
            this.jsonBtn.UseVisualStyleBackColor = true;
            this.jsonBtn.Click += new System.EventHandler(this.jsonBtn_Click);
            // 
            // indexBtn
            // 
            this.indexBtn.Enabled = false;
            this.indexBtn.Location = new System.Drawing.Point(674, 100);
            this.indexBtn.Name = "indexBtn";
            this.indexBtn.Size = new System.Drawing.Size(114, 38);
            this.indexBtn.TabIndex = 2;
            this.indexBtn.Text = "Start Indexing";
            this.indexBtn.UseVisualStyleBackColor = true;
            this.indexBtn.Click += new System.EventHandler(this.indexBtn_Click);
            // 
            // searchBox
            // 
            this.searchBox.Enabled = false;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(13, 13);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(426, 29);
            this.searchBox.TabIndex = 3;
            // 
            // simpleSearchRadio
            // 
            this.simpleSearchRadio.AutoSize = true;
            this.simpleSearchRadio.Location = new System.Drawing.Point(13, 48);
            this.simpleSearchRadio.Name = "simpleSearchRadio";
            this.simpleSearchRadio.Size = new System.Drawing.Size(93, 17);
            this.simpleSearchRadio.TabIndex = 4;
            this.simpleSearchRadio.Text = "Simple Search";
            this.simpleSearchRadio.UseVisualStyleBackColor = true;
            // 
            // advanceSearchRadio
            // 
            this.advanceSearchRadio.AutoSize = true;
            this.advanceSearchRadio.Checked = true;
            this.advanceSearchRadio.Location = new System.Drawing.Point(134, 48);
            this.advanceSearchRadio.Name = "advanceSearchRadio";
            this.advanceSearchRadio.Size = new System.Drawing.Size(105, 17);
            this.advanceSearchRadio.TabIndex = 5;
            this.advanceSearchRadio.TabStop = true;
            this.advanceSearchRadio.Text = "Advance Search";
            this.advanceSearchRadio.UseVisualStyleBackColor = true;
            this.advanceSearchRadio.CheckedChanged += new System.EventHandler(this.advanceSearchRadio_CheckedChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Enabled = false;
            this.searchBtn.Location = new System.Drawing.Point(445, 13);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(92, 29);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // AdvanceGroup
            // 
            this.AdvanceGroup.Controls.Add(this.PageRankCheckBox);
            this.AdvanceGroup.Controls.Add(this.label6);
            this.AdvanceGroup.Controls.Add(this.label5);
            this.AdvanceGroup.Controls.Add(this.label4);
            this.AdvanceGroup.Controls.Add(this.timeWeight);
            this.AdvanceGroup.Controls.Add(this.abstractWeight);
            this.AdvanceGroup.Controls.Add(this.titleWeight);
            this.AdvanceGroup.Controls.Add(this.label3);
            this.AdvanceGroup.Controls.Add(this.timeBox);
            this.AdvanceGroup.Controls.Add(this.label2);
            this.AdvanceGroup.Controls.Add(this.abstractBox);
            this.AdvanceGroup.Controls.Add(this.label1);
            this.AdvanceGroup.Controls.Add(this.titleBox);
            this.AdvanceGroup.Location = new System.Drawing.Point(13, 71);
            this.AdvanceGroup.Name = "AdvanceGroup";
            this.AdvanceGroup.Size = new System.Drawing.Size(524, 367);
            this.AdvanceGroup.TabIndex = 7;
            this.AdvanceGroup.TabStop = false;
            this.AdvanceGroup.Text = "Advance Search Filters";
            // 
            // PageRankCheckBox
            // 
            this.PageRankCheckBox.AutoSize = true;
            this.PageRankCheckBox.Location = new System.Drawing.Point(58, 131);
            this.PageRankCheckBox.Name = "PageRankCheckBox";
            this.PageRankCheckBox.Size = new System.Drawing.Size(77, 17);
            this.PageRankCheckBox.TabIndex = 12;
            this.PageRankCheckBox.Text = "PageRank";
            this.PageRankCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(439, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(199, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Filter";
            // 
            // timeWeight
            // 
            this.timeWeight.Location = new System.Drawing.Point(398, 104);
            this.timeWeight.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.timeWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeWeight.Name = "timeWeight";
            this.timeWeight.Size = new System.Drawing.Size(120, 20);
            this.timeWeight.TabIndex = 8;
            this.timeWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // abstractWeight
            // 
            this.abstractWeight.Location = new System.Drawing.Point(398, 78);
            this.abstractWeight.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.abstractWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.abstractWeight.Name = "abstractWeight";
            this.abstractWeight.Size = new System.Drawing.Size(120, 20);
            this.abstractWeight.TabIndex = 7;
            this.abstractWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.abstractWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // titleWeight
            // 
            this.titleWeight.Location = new System.Drawing.Point(398, 50);
            this.titleWeight.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.titleWeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.titleWeight.Name = "titleWeight";
            this.titleWeight.Size = new System.Drawing.Size(120, 20);
            this.titleWeight.TabIndex = 6;
            this.titleWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.titleWeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(58, 104);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(334, 20);
            this.timeBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Abstract";
            // 
            // abstractBox
            // 
            this.abstractBox.Location = new System.Drawing.Point(58, 78);
            this.abstractBox.Name = "abstractBox";
            this.abstractBox.Size = new System.Drawing.Size(334, 20);
            this.abstractBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Title";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(58, 50);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(334, 20);
            this.titleBox.TabIndex = 0;
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.Color.LightCoral;
            this.connectBtn.Location = new System.Drawing.Point(674, 400);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(114, 38);
            this.connectBtn.TabIndex = 8;
            this.connectBtn.Text = "Connect to Elasticsearch";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.AdvanceGroup);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.advanceSearchRadio);
            this.Controls.Add(this.simpleSearchRadio);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.indexBtn);
            this.Controls.Add(this.jsonBtn);
            this.Controls.Add(this.csvBtn);
            this.Name = "Form1";
            this.Text = "COVID-19 Research";
            this.AdvanceGroup.ResumeLayout(false);
            this.AdvanceGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.abstractWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.titleWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button csvBtn;
        private System.Windows.Forms.Button jsonBtn;
        private System.Windows.Forms.Button indexBtn;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.RadioButton simpleSearchRadio;
        private System.Windows.Forms.RadioButton advanceSearchRadio;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.GroupBox AdvanceGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox abstractBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown timeWeight;
        private System.Windows.Forms.NumericUpDown abstractWeight;
        private System.Windows.Forms.NumericUpDown titleWeight;
        private System.Windows.Forms.CheckBox PageRankCheckBox;
        private System.Windows.Forms.Button connectBtn;
    }
}

