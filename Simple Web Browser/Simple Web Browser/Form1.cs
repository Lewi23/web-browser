using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace Simple_Web_Browser
{
    public partial class Form1 : Form
    {

 
        public Form1()
        {
            InitializeComponent();
        }

        private void menuButton_Click(object sender, EventArgs e)
        {

        }

        private void backPageButton_Click(object sender, EventArgs e)
        {

        }

        private void forwardPageButton_Click(object sender, EventArgs e)
        {

        }
        private void resultDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        private async void searchButton_Click(object sender, EventArgs e)
        {
            Manager test = new Manager();
            Console.WriteLine(test.getWebsite(inputBox.Text));
            resultDisplay.Text = await test.getWebsite(inputBox.Text);
        }
        private void refreshPageButon_Click(object sender, EventArgs e)
        {

        }
    }
}
