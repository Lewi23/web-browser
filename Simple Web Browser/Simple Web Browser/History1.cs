using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public class History1
    {

        public static List<HistoryItem> historyList = new List<HistoryItem>();
        public event EventHandler historyItem;
        public static int pagePointer = -1;

        public History1()
        {

        }

        public bool canStepBack() => historyList.ElementAtOrDefault(pagePointer - 1) != null ? true : false;
        public bool canStepForward() => historyList.ElementAtOrDefault(pagePointer + 1) != null ? true : false;
      
        public void loadHistory()
        {
            OnHistoryUpdate(EventArgs.Empty);
        }

        public void addToHistory(string url)
        {
            HistoryItem historyItem = new HistoryItem();
            historyItem.historyURL = url;
            historyItem.accessTime = DateTime.Now;
            historyList.Add(historyItem);

            pagePointer++;

            OnHistoryUpdate(EventArgs.Empty);
        }

        public void deleteHistoryItem(int index)
        {
            historyList.RemoveAt(index);

            // This is handling an edge case of deletion ( if you delete the page you are on with only 1 other page)
            if(pagePointer < 1)
            {
                pagePointer--;
            }
            
            Console.WriteLine("THE PAGE POINTER : " + pagePointer);

            OnHistoryUpdate(EventArgs.Empty);
        }

        protected virtual void OnHistoryUpdate(EventArgs e)
        {
            EventHandler handler = historyItem;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }

    public class HistoryItem
    {
        public string historyURL { get; set; }
        public DateTime accessTime { get; set; }
    }

}
