using Simple_Web_Browser.Properties;
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

        public static List<HistoryItem> historyList;
        public event EventHandler historyItem;
        //public static int pagePointer = -1;
        public static int pagePointer;
        XML<HistoryItem> xml = new XML<HistoryItem>();

        public History()
        {
            historyList = loadLocalHistory();
        }

        public bool canStepBack() => historyList.ElementAtOrDefault(pagePointer - 1) != null ? true : false;
        public bool canStepForward() => historyList.ElementAtOrDefault(pagePointer + 1) != null ? true : false;
      
        public void loadHistory()
        {
            OnHistoryUpdate(EventArgs.Empty);
            pagePointer = historyList.Count - 1;
        }

        public void addToHistory(string url)
        {
            HistoryItem historyItem = new HistoryItem();
            historyItem.historyURL = url;
            historyItem.accessTime = DateTime.Now;
            historyList.Add(historyItem);

            //pagePointer++;
            saveHistoryLocally();

            OnHistoryUpdate(EventArgs.Empty);
        }

        public void deleteHistoryItem(int index)
        {
            historyList.RemoveAt(index);

            saveHistoryLocally();
            // This is handling an edge case of deletion ( if you delete the page you are on with only 1 other page)
            if (pagePointer > 1)
            {
                //pagePointer--;
            }
            
            Console.WriteLine("THE PAGE POINTER : " + pagePointer);

            //saveHistoryLocally();
            OnHistoryUpdate(EventArgs.Empty);
        }

        public void saveHistoryLocally()
        {
            xml.writeListToXML(historyList, Resources.SearchHistory);
        }

        public List<HistoryItem> loadLocalHistory()
        {
            List<HistoryItem> list;
            list = xml.readXMLToList(Resources.SearchHistory);

            return list;

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
