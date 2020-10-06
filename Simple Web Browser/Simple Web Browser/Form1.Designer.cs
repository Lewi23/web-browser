namespace Simple_Web_Browser
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
            this.menuButton = new System.Windows.Forms.Button();
            this.resultDisplay = new System.Windows.Forms.RichTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.backPageButton = new System.Windows.Forms.Button();
            this.forwardPageButton = new System.Windows.Forms.Button();
            this.refreshPageButon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.menuButton.Location = new System.Drawing.Point(680, 12);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(87, 33);
            this.menuButton.TabIndex = 0;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // resultDisplay
            // 
            this.resultDisplay.Location = new System.Drawing.Point(13, 51);
            this.resultDisplay.Name = "resultDisplay";
            this.resultDisplay.Size = new System.Drawing.Size(754, 483);
            this.resultDisplay.TabIndex = 1;
            this.resultDisplay.Text = "";
            this.resultDisplay.TextChanged += new System.EventHandler(this.resultDisplay_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.searchButton.Location = new System.Drawing.Point(616, 13);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(58, 32);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Go";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.inputBox.Location = new System.Drawing.Point(163, 15);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(447, 26);
            this.inputBox.TabIndex = 3;
            this.inputBox.TextChanged += new System.EventHandler(this.resultDisplay_TextChanged);
            // 
            // backPageButton
            // 
            this.backPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backPageButton.Location = new System.Drawing.Point(13, 13);
            this.backPageButton.Name = "backPageButton";
            this.backPageButton.Size = new System.Drawing.Size(44, 32);
            this.backPageButton.TabIndex = 4;
            this.backPageButton.Text = "⬅️";
            this.backPageButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backPageButton.UseVisualStyleBackColor = true;
            this.backPageButton.Click += new System.EventHandler(this.backPageButton_Click);
            // 
            // forwardPageButton
            // 
            this.forwardPageButton.Location = new System.Drawing.Point(63, 13);
            this.forwardPageButton.Name = "forwardPageButton";
            this.forwardPageButton.Size = new System.Drawing.Size(42, 32);
            this.forwardPageButton.TabIndex = 5;
            this.forwardPageButton.Text = "fwd";
            this.forwardPageButton.UseVisualStyleBackColor = true;
            this.forwardPageButton.Click += new System.EventHandler(this.forwardPageButton_Click);
            // 
            // refreshPageButon
            // 
            this.refreshPageButon.Location = new System.Drawing.Point(112, 13);
            this.refreshPageButon.Name = "refreshPageButon";
            this.refreshPageButon.Size = new System.Drawing.Size(45, 32);
            this.refreshPageButon.TabIndex = 6;
            this.refreshPageButon.Text = "refresh";
            this.refreshPageButon.UseVisualStyleBackColor = true;
            this.refreshPageButon.Click += new System.EventHandler(this.refreshPageButon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 544);
            this.Controls.Add(this.refreshPageButon);
            this.Controls.Add(this.forwardPageButton);
            this.Controls.Add(this.backPageButton);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultDisplay);
            this.Controls.Add(this.menuButton);
            this.Name = "Form1";
            this.Text = "Simple Web Browser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button menuButton;
        public System.Windows.Forms.RichTextBox resultDisplay;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button backPageButton;
        private System.Windows.Forms.Button forwardPageButton;
        private System.Windows.Forms.Button refreshPageButon;
    }
}

