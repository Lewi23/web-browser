namespace Simple_Web_Browser
{
    public partial class setHomepage
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
            this.homepageLabel = new System.Windows.Forms.Label();
            this.homepageURLBox = new System.Windows.Forms.TextBox();
            this.setHomepageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // homepageLabel
            // 
            this.homepageLabel.AutoSize = true;
            this.homepageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.homepageLabel.Location = new System.Drawing.Point(12, 9);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(247, 26);
            this.homepageLabel.TabIndex = 0;
            this.homepageLabel.Text = "Please set a homepage:";
            this.homepageLabel.Click += new System.EventHandler(this.homepageLabel_Click);
            // 
            // homepageURLBox
            // 
            this.homepageURLBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.homepageURLBox.Location = new System.Drawing.Point(17, 48);
            this.homepageURLBox.Name = "homepageURLBox";
            this.homepageURLBox.Size = new System.Drawing.Size(350, 26);
            this.homepageURLBox.TabIndex = 1;
            // 
            // setHomepageButton
            // 
            this.setHomepageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setHomepageButton.Location = new System.Drawing.Point(17, 89);
            this.setHomepageButton.Name = "setHomepageButton";
            this.setHomepageButton.Size = new System.Drawing.Size(350, 29);
            this.setHomepageButton.TabIndex = 2;
            this.setHomepageButton.Text = "Set";
            this.setHomepageButton.UseVisualStyleBackColor = true;
            this.setHomepageButton.Click += new System.EventHandler(this.setHomepageButton_Click);
            // 
            // setHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 139);
            this.Controls.Add(this.setHomepageButton);
            this.Controls.Add(this.homepageURLBox);
            this.Controls.Add(this.homepageLabel);
            this.Name = "setHomepage";
            this.Text = "Simple Web Browser";
            this.Load += new System.EventHandler(this.setHomepage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label homepageLabel;
        public System.Windows.Forms.TextBox homepageURLBox;
        public System.Windows.Forms.Button setHomepageButton;
    }
}