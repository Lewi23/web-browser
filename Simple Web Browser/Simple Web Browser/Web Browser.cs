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
    public partial class Browser : Form
    {

        public Manager manager;
        public History historyManager;

        public Browser()
        {
            InitializeComponent();
            manager = new Manager();
            historyManager = new History();
            manager.RequestComplete += m_RequestComplete;
            //manager.historyManager.HistoryItem += HistoryManager_HistoryItem;

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(this);
            frm.Show();
        }

        private void backPageButton_Click(object sender, EventArgs e)
        {
            if (historyManager.canStepBack())
            {
                manager.getPreviousPage();
                forwardPageButton.Enabled = true;

                //check the next canStepBack() item if it's false we have reached the end of history
                if (!historyManager.canStepBack())
                {
                    backPageButton.Enabled = false;
                }
                    
            } else
            {
                // We can no longer step back
                backPageButton.Enabled = false;
            }

        }

        private void forwardPageButton_Click(object sender, EventArgs e)
        {
            if (historyManager.canStepForward())
            {
                manager.getNextPage();
                backPageButton.Enabled = true;

                //check the next canStepForward() item if it's false we have reached the end of history
                if (!historyManager.canStepForward())
                {
                    forwardPageButton.Enabled = false;
                }
            }
            else
            {
                // We can no longer step forward
                forwardPageButton.Enabled = false;
            }
        }

      

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (manager.validURL(URLinputBox.Text))
            {
                manager.getWebsite(URLinputBox.Text, true);
                backPageButton.Enabled = true;
            } else
            {
                System.Windows.Forms.MessageBox.Show("Invalid URL", "Error");
            }
            

        }

        void m_RequestComplete(object sender, RequestCompleteArgs e)
        {
            //Console.WriteLine(e.pageData);
            //Console.WriteLine(e.request);
            //Console.WriteLine(e.title);

            resultDisplay.Text = e.pageData;
            URLinputBox.Text = e.URL;
            titleHolder.Text = e.title;
            HTTPHolder.Text = e.request;

        }


        private void refreshPageButon_Click(object sender, EventArgs e)
        {
            manager.reloadPage();
        }
      

        private void Browser_Load(object sender, EventArgs e)
        {
            

            // Load the users preset form
            manager.setHomepage(manager.getHomeURL());
            manager.getWebsite(manager.getHomeURL(), true);

            historyManager.loadHistory();
            Console.WriteLine(History.historyList.Count);

            if (History.historyList.Count > 0)
                backPageButton.Enabled = true;
            else
                backPageButton.Enabled = false;

            // This is false until we search a page
            forwardPageButton.Enabled = false;



            // In theory you shouldn't ever be able to go forward but might be able to go backwords if history loads
        }
        
    }
}
