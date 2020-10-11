using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public partial class Form2 : Form
    {
        //History historyManager = new History;

        public Form2()
        {
            InitializeComponent();
        }

        private Form1 mainForm = null;
        // https://stackoverflow.com/questions/1665533/communicate-between-two-windows-forms-in-c-sharp
        // communcatiing between two forms
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
            this.mainForm.manager.historyManager.HistoryItem += updateList;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

            foreach(HistoryItemArgs item in this.mainForm.manager.historyManager.HistoryList)
            {
                string builder = "URL: " + item.pageURL + " | Accessed: " + item.CurrentTime;
                Console.WriteLine("Bulder : {0}", builder);

                
                    historyBox.Items.Add(builder);
                

                
            }
        }

        void updateList(Object sender, HistoryItemArgs e)
        {
            HistoryItemArgs item = new HistoryItemArgs();
            item.pageURL = e.pageURL;
            item.CurrentTime = e.CurrentTime;
            this.mainForm.manager.historyManager.HistoryList.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainForm.resultDisplay.Text = "hello world";

            historyBox.Items.Add("hello");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
