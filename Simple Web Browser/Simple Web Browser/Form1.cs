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

        public Manager manager;
        public History historyManager;
        // History historyManager = manager.historyManager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager();
            historyManager = new History();
            manager.RequestComplete += m_RequestComplete;
            //manager.historyManager.HistoryItem += HistoryManager_HistoryItem;

        }


        private void menuButton_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private void backPageButton_Click(object sender, EventArgs e)
        {

            // manager.getWebsite(manager.historyManager.getPreviousPage(), false);
            if (historyManager.canStepBack())
            {
                manager.getPreviousPage();
            }

        }

        private void forwardPageButton_Click(object sender, EventArgs e)
        {

            //manager.getWebsite(manager.historyManager.getNextPage(), false);
            if (historyManager.canStepForward())
            {
                manager.getNextPage();
            }
            

        }

      

        private void searchButton_Click(object sender, EventArgs e)
        {
           
            manager.getWebsite(inputBox.Text, true);

        }

        void m_RequestComplete(object sender, RequestCompleteArgs e)
        {
            //Console.WriteLine(e.pageData);
            //Console.WriteLine(e.request);
            //Console.WriteLine(e.title);

            resultDisplay.Text = e.pageData;
            inputBox.Text = e.URL;
            titleHolder.Text = e.title;
            HTTPHolder.Text = e.request;

        }


        private async void refreshPageButon_Click(object sender, EventArgs e)
        {
            // resultDisplay.Text = await manager.getWebsite(manager.currentURL, true);
            // refreshPageButon.Click += new EventHandler(NameButtonClicked);
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {

            // Load the users preset form
            manager.setHomePage("https://www.google.com/");
            manager.getWebsite(manager.currentURL, true);

            // In theory you shouldn't ever be able to go forward but might be able to go backwords if history loads
        }

        /*
        private void HistoryManager_HistoryItem(object sender, HistoryItemArgs e)
        {
           // System.Console.WriteLine("EVENT CALLED");

            HistoryItemArgs item = new HistoryItemArgs();
            item.pageURL = e.pageURL;
            item.CurrentTime = e.CurrentTime;

            System.Console.WriteLine(item.pageURL);
            System.Console.WriteLine(item.CurrentTime);

            manager.historyManager.HistoryList.Add(item);
        }
        */


        private void resultDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Step back : " + historyManager.canStepBack());
            if (historyManager.canStepBack())
            {
                manager.getPreviousPage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Step forward : " + historyManager.canStepForward());
            if (historyManager.canStepForward())
            {
                manager.getNextPage();
            }
        }
    }
}
