namespace Simple_Web_Browser
{
    partial class Form2
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.historyBox = new System.Windows.Forms.ListBox();
            this.historySearch = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Seach google";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(225, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // historyBox
            // 
            this.historyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.historyBox.FormattingEnabled = true;
            this.historyBox.HorizontalScrollbar = true;
            this.historyBox.ItemHeight = 20;
            this.historyBox.Location = new System.Drawing.Point(32, 122);
            this.historyBox.Name = "historyBox";
            this.historyBox.Size = new System.Drawing.Size(578, 224);
            this.historyBox.TabIndex = 2;
            this.historyBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // historySearch
            // 
            this.historySearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.historySearch.Location = new System.Drawing.Point(204, 82);
            this.historySearch.Name = "historySearch";
            this.historySearch.Size = new System.Drawing.Size(76, 34);
            this.historySearch.TabIndex = 3;
            this.historySearch.Text = "Search";
            this.historySearch.UseVisualStyleBackColor = true;
            this.historySearch.Click += new System.EventHandler(this.historySearch_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(434, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteHistory
            // 
            this.deleteHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteHistory.Location = new System.Drawing.Point(286, 82);
            this.deleteHistory.Name = "deleteHistory";
            this.deleteHistory.Size = new System.Drawing.Size(90, 34);
            this.deleteHistory.TabIndex = 5;
            this.deleteHistory.Text = "Delete";
            this.deleteHistory.UseVisualStyleBackColor = true;
            this.deleteHistory.Click += new System.EventHandler(this.deleteHistory_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 372);
            this.Controls.Add(this.deleteHistory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.historySearch);
            this.Controls.Add(this.historyBox);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ListBox historyBox;
        private System.Windows.Forms.Button historySearch;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteHistory;
    }
}