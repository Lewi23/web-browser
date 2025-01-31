﻿namespace Simple_Web_Browser
{
    partial class webBrowser
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
            this.menuButton = new System.Windows.Forms.Button();
            this.resultDisplay = new System.Windows.Forms.RichTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.URLinputBox = new System.Windows.Forms.TextBox();
            this.backPageButton = new System.Windows.Forms.Button();
            this.forwardPageButton = new System.Windows.Forms.Button();
            this.refreshPageButon = new System.Windows.Forms.Button();
            this.HTTPlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titleHolder = new System.Windows.Forms.Label();
            this.HTTPHolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuButton.Location = new System.Drawing.Point(700, 13);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(87, 33);
            this.menuButton.TabIndex = 0;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // resultDisplay
            // 
            this.resultDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.resultDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.resultDisplay.Location = new System.Drawing.Point(13, 124);
            this.resultDisplay.Name = "resultDisplay";
            this.resultDisplay.Size = new System.Drawing.Size(774, 473);
            this.resultDisplay.TabIndex = 1;
            this.resultDisplay.Text = "";
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchButton.Location = new System.Drawing.Point(616, 13);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(78, 32);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // URLinputBox
            // 
            this.URLinputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.URLinputBox.Location = new System.Drawing.Point(163, 15);
            this.URLinputBox.Name = "URLinputBox";
            this.URLinputBox.Size = new System.Drawing.Size(447, 26);
            this.URLinputBox.TabIndex = 3;
            // 
            // backPageButton
            // 
            this.backPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.backPageButton.Location = new System.Drawing.Point(13, 13);
            this.backPageButton.Name = "backPageButton";
            this.backPageButton.Size = new System.Drawing.Size(44, 32);
            this.backPageButton.TabIndex = 4;
            this.backPageButton.Text = "←";
            this.backPageButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backPageButton.UseVisualStyleBackColor = true;
            this.backPageButton.Click += new System.EventHandler(this.backPageButton_Click);
            // 
            // forwardPageButton
            // 
            this.forwardPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.forwardPageButton.Location = new System.Drawing.Point(63, 13);
            this.forwardPageButton.Name = "forwardPageButton";
            this.forwardPageButton.Size = new System.Drawing.Size(42, 32);
            this.forwardPageButton.TabIndex = 5;
            this.forwardPageButton.Text = "→";
            this.forwardPageButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.forwardPageButton.UseVisualStyleBackColor = true;
            this.forwardPageButton.Click += new System.EventHandler(this.forwardPageButton_Click);
            // 
            // refreshPageButon
            // 
            this.refreshPageButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.refreshPageButon.Location = new System.Drawing.Point(112, 13);
            this.refreshPageButon.Name = "refreshPageButon";
            this.refreshPageButon.Size = new System.Drawing.Size(45, 32);
            this.refreshPageButon.TabIndex = 6;
            this.refreshPageButon.Text = "⟳";
            this.refreshPageButon.UseVisualStyleBackColor = true;
            this.refreshPageButon.Click += new System.EventHandler(this.refreshPageButon_Click);
            // 
            // HTTPlabel
            // 
            this.HTTPlabel.AutoSize = true;
            this.HTTPlabel.BackColor = System.Drawing.SystemColors.Info;
            this.HTTPlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.HTTPlabel.Location = new System.Drawing.Point(12, 62);
            this.HTTPlabel.Name = "HTTPlabel";
            this.HTTPlabel.Size = new System.Drawing.Size(146, 20);
            this.HTTPlabel.TabIndex = 7;
            this.HTTPlabel.Text = "HTTP Status Code:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(16, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title:";
            // 
            // titleHolder
            // 
            this.titleHolder.AutoSize = true;
            this.titleHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.titleHolder.Location = new System.Drawing.Point(64, 91);
            this.titleHolder.Name = "titleHolder";
            this.titleHolder.Size = new System.Drawing.Size(0, 20);
            this.titleHolder.TabIndex = 9;
            // 
            // HTTPHolder
            // 
            this.HTTPHolder.AutoSize = true;
            this.HTTPHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.HTTPHolder.Location = new System.Drawing.Point(159, 62);
            this.HTTPHolder.Name = "HTTPHolder";
            this.HTTPHolder.Size = new System.Drawing.Size(0, 20);
            this.HTTPHolder.TabIndex = 10;
            // 
            // webBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 600);
            this.Controls.Add(this.HTTPHolder);
            this.Controls.Add(this.titleHolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HTTPlabel);
            this.Controls.Add(this.refreshPageButon);
            this.Controls.Add(this.forwardPageButton);
            this.Controls.Add(this.backPageButton);
            this.Controls.Add(this.URLinputBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultDisplay);
            this.Controls.Add(this.menuButton);
            this.KeyPreview = true;
            this.Name = "webBrowser";
            this.Text = "Simple Web Browser";
            this.Load += new System.EventHandler(this.webBrowser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webBrowser_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button menuButton;
        public System.Windows.Forms.RichTextBox resultDisplay;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox URLinputBox;
        private System.Windows.Forms.Button backPageButton;
        private System.Windows.Forms.Button forwardPageButton;
        private System.Windows.Forms.Button refreshPageButon;
        private System.Windows.Forms.Label HTTPlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleHolder;
        private System.Windows.Forms.Label HTTPHolder;
    }
}

