using System;
using System.Windows.Forms;


namespace Simple_Web_Browser
{
    /// <summary>
    /// This class implements how the form elements behave for the web browser 
    /// </summary>
    public partial class webBrowser : Form
    {

        public Manager manager;
        public History historyManager;

        /// <summary>
        /// Default constructor
        /// </summary>
        public webBrowser()
        {
            InitializeComponent();
            manager = new Manager();
            historyManager = new History();

            //Linking the delegate to the method
            manager.RequestComplete += m_RequestComplete;
            

        }

        /// <summary>
        /// Open the Menu form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuButton_Click(object sender, EventArgs e)
        {
            menu form = new menu(this);
            form.Show();
        }

        /// <summary>
        /// Takes the user to the previous page if it exists otherwise disable the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backPageButton_Click(object sender, EventArgs e)
        {
            try
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

                }
                else
                {
                    Console.WriteLine("Cant go back" + History.pagePointer);
                    //We can no longer step back
                    backPageButton.Enabled = false;
                }
            }
            catch(ArgumentOutOfRangeException a)
            {
                System.Windows.Forms.MessageBox.Show(a.Message);
            }
            

        }

        /// <summary>
        /// Takes the user to the next page if it exists otherwise disable the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void forwardPageButton_Click(object sender, EventArgs e)
        {

            try
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
                    Console.WriteLine("Cant go forward" + History.pagePointer);
                    // We can no longer step forward
                    forwardPageButton.Enabled = false;
                }
            }
            catch (ArgumentOutOfRangeException a)
            {
                System.Windows.Forms.MessageBox.Show(a.Message); 
            }
        }
        


    /// <summary>
    /// Loads the URL from the URL input box if it is valid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void searchButton_Click(object sender, EventArgs e)
        {
            if (manager.validURL(URLinputBox.Text))
            {
                manager.loadWebsite(URLinputBox.Text, true);
                backPageButton.Enabled = true;
            } else
            {
                System.Windows.Forms.MessageBox.Show("Invalid URL");
            }
        }

        /// <summary>
        /// Event triggered from manager class, updates all of the web page data on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void m_RequestComplete(object sender, RequestCompleteArgs e)
        {

            resultDisplay.Text = e.pageData;
            URLinputBox.Text = e.URL;
            titleHolder.Text = e.title;
            HTTPHolder.Text = e.request;

        }

        /// <summary>
        /// Reloads the current page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshPageButon_Click(object sender, EventArgs e)
        {
            manager.reloadPage();
        }
      
        /// <summary>
        /// Sets up the users browser by loading their home URL and history to determine if they can navigate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_Load(object sender, EventArgs e)
        {
            
            // load the users homepage into manager
            manager.setHomepage(manager.getHomeURL());
            // get the website that is the home URL
            manager.loadWebsite(manager.getHomeURL(), true);

            // Need to load history here to check if the back buttons can be enabled on launch
            historyManager.loadHistory();
          
            // Checking if the back page button is enabled
            if (History.historyList.Count > 0)
            {
               backPageButton.Enabled = true;
            }
            else
            {
               backPageButton.Enabled = false;
            }
                
            // This is false until we search a page
            forwardPageButton.Enabled = false;

        }

        /// <summary>
        /// Keybinds for ease of use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    refreshPageButon.PerformClick();
                    break;
                case Keys.Enter:
                    searchButton.PerformClick();
                    break;
                case Keys.F11:
                    menuButton.PerformClick();
                    break;
                case Keys.F1:
                    backPageButton.PerformClick();
                    break;
                case Keys.F2:
                    forwardPageButton.PerformClick();
                    break;
            }
        }
    }
}
