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
using System.Text.RegularExpressions;

namespace Simple_Web_Browser
{
    public partial class Form1 : Form
    {

        Manager manager;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private void backPageButton_Click(object sender, EventArgs e)
        {

        }

        private void forwardPageButton_Click(object sender, EventArgs e)
        {

        }
        void resultDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        private async void searchButton_Click(object sender, EventArgs e)
        {
            

            try
            {
                resultDisplay.Text = await manager.getWebsite(inputBox.Text);
            }
            catch (Exception exp) { 
            
                resultDisplay.Text = exp.Message;
            }
        }
        private async void refreshPageButon_Click(object sender, EventArgs e)
        {
            resultDisplay.Text = await manager.getWebsite(manager.currentURL);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            manager = new Manager();
            resultDisplay.Text = await manager.getWebsite(manager.currentURL);
            inputBox.Text = manager.currentURL;
            // ref this
            titleHolder.Text = manager.title;
            HTTPHolder.Text = manager.request;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
