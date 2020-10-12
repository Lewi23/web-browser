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
        // History historyManager = manager.historyManager;

        public Form1()
        {
            InitializeComponent();
            manager = new Manager();
            manager.RequestComplete += m_RequestComplete;
            manager.historyManager.HistoryItem += HistoryManager_HistoryItem;

        }


        private void menuButton_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }

        private void backPageButton_Click(object sender, EventArgs e)
        {

           
                // manager.getWebsite(manager.historyManager.getPreviousPage(), false);
                /*
            if (manager.historyManager.CanStepBack())
            {
                */
                manager.getWebsite(manager.historyManager.getPreviousPage(), false);
            /*
                forwardPageButton.Enabled = true;
            } else
            {
                Console.WriteLine("cant step back");
                backPageButton.Enabled = false;
                forwardPageButton.Enabled = true;
            }
            */
            




            // resultDisplay.Text = await manager.getWebsite(manager.historyManager.getPreviousPage(), true);
            //inputBox.Text = manager.currentURL;
            //titleHolder.Text = manager.title;
            // HTTPHolder.Text = manager.request;

            /*
        
            */
        }

        private void forwardPageButton_Click(object sender, EventArgs e)
        {
            // resultDisplay.Text = await manager.getWebsite(manager.historyManager.getNextPage(), true);
            //inputBox.Text = manager.currentURL;
            //titleHolder.Text = manager.title;
            //HTTPHolder.Text = manager.request;

         
                // manager.getWebsite(manager.historyManager.getNextPage(), false);
                /*
            if (manager.historyManager.CanStepForward())
            {
                Console.WriteLine("can step forward");
                */
                manager.getWebsite(manager.historyManager.getNextPage(), false);
            /*
                backPageButton.Enabled = true;
                
            } else
            {
                backPageButton.Enabled = true;
                forwardPageButton.Enabled = false;
            }
                
            */

            

            
        }
      
        private async void searchButton_Click(object sender, EventArgs e)
        {

                manager.getWebsite(inputBox.Text, true);

                //backPageButton.Enabled = true;

                

                // resultDisplay.Text = await manager.getWebsite(inputBox.Text, false);
                //titleHolder.Text = manager.title;
                //HTTPHolder.Text = manager.request;

                // manager.PageUpdate += m_PageUpdate;
                //manager.RequestComplete += m_RequestComplete;

                // you have no searched something so can go backwords at least once
                /*
                if (manager.historyManager.addedURL)
                {
                    backPageButton.Enabled = true;
                }

                */

         
            
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
        /*
        private void NameButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("We fired off an event!");
        }

        */

        private void Form1_Load(object sender, EventArgs e)
        {

            manager.getWebsite(manager.currentURL, false);

            // When the form loads you can't step forwards or backwords (haven't gone anywhere)
            //backPageButton.Enabled = false;
            //forwardPageButton.Enabled = false;

            

        }


        private void HistoryManager_HistoryItem(object sender, HistoryItemArgs e)
        {
            System.Console.WriteLine("EVENT CALLED");

            HistoryItemArgs item = new HistoryItemArgs();
            item.pageURL = e.pageURL;
            item.CurrentTime = e.CurrentTime;

            System.Console.WriteLine(item.pageURL);
            System.Console.WriteLine(item.CurrentTime);

            manager.historyManager.HistoryList.Add(item);
        }



        private void resultDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
