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
        public static int index = -1;

        public History1()
        {

        }

        public bool canStepBack()
        {
            bool result = false;

            if(historyList.ElementAtOrDefault(index - 1) != null)
            {
                result = true;
                //index--;
            } 

            return result;
        }

        public bool canStepForward()
        {
            bool result = false;

            if (historyList.ElementAtOrDefault(index + 1) != null)
            {
                result = true;
                //index++;
            }

            return result;
        }


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

            index++;

            OnHistoryUpdate(EventArgs.Empty);
        }

        public void deleteHistoryItem(int index)
        {
            historyList.RemoveAt(index);

            index--;

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
