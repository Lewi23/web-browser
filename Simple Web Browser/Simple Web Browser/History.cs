using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public class History
    {

        // History stuff

        public event EventHandler getNpage;

        public static List<string> item = new List<string>();
        static public int index = 0;
        static string url = "";

        public bool CanStepBack = item.ElementAtOrDefault(index - 1) != null ? true : false;
        public bool CanStepForward = item.ElementAtOrDefault(index + 1) != null ? true : false;
        public bool addedURL;

        public History()
        {

        }

        public History(string initalURI)
        {

            item.Add(initalURI);
            url = initalURI;

            /*a
            foreach (string x in item)
            {
                Console.WriteLine(x);
            }
            */
        }
        

        public string getNextPage()
        {

            index++;
            Console.WriteLine("Returning {0} at index {1}",item[index], index);
            return item[index];
        }

        
        public string getPreviousPage()
        { 
            index--;
            Console.WriteLine("Returning {0} at index {1}", item[index], index);
            return item[index];
        }

        public void addToHistory(string URL)
        {
            // don't add an element to history if the same URL is trying to be added again 
            if(item.ElementAt(item.Count -1) != URL)
            {
                index++;
                item.Add(URL);
                addedURL = true;

                HistoryItemArgs args = new HistoryItemArgs();
                args.pageURL = URL;
                args.CurrentTime = DateTime.Now;
                OnHistoryItem(args);

            } else
            {
                addedURL = false;
            }

        }

        protected virtual void OnHistoryItem(HistoryItemArgs e)
        {
            EventHandler<HistoryItemArgs> handler = HistoryItem;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<HistoryItemArgs> HistoryItem;

        public List<HistoryItemArgs> HistoryList = new List<HistoryItemArgs>();

    }

    public class HistoryItemArgs : EventArgs
    {
        public string pageURL { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
