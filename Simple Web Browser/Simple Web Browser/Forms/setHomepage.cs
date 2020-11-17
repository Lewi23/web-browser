using System;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public partial class setHomepage : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public setHomepage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the form (submits), manager class then validates the provided URL is valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setHomepageButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
