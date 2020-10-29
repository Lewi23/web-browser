using Simple_Web_Browser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Web_Browser
{
    /// <summary>
    /// This class is responsible for managing the history of the web browser
    /// </summary>
    public class History
    {

        public static List<HistoryItem> historyList;
        public event EventHandler historyItem;
        public static int pagePointer;
        XML<HistoryItem> historyXMLManager = new XML<HistoryItem>();

        /// <summary>
        /// Default constructor, loads the local history into historyList
        /// </summary>
        public History()
        {
            historyList = new List<HistoryItem>();
        }

        /// <summary>
        /// Checks if we can step back 1 page in history
        /// </summary>
        /// <returns>True if it is possible to step back in hisotry otherwise false</returns>
        public bool canStepBack() => historyList.ElementAtOrDefault(pagePointer - 1) != null ? true : false;

        /// <summary>
        /// Checks if we can step forward 1 page in history
        /// </summary>
        /// <returns>True if it is possible to step forward in hisotry otherwise false</returns>
        public bool canStepForward() => historyList.ElementAtOrDefault(pagePointer + 1) != null ? true : false;
        
        /// <summary>
        /// Loads history from local storage
        /// </summary>
        public void loadHistory()
        {
            historyList = loadLocalHistory();
            OnHistoryUpdate(EventArgs.Empty);

            if(historyList.Count == 0)
            {
                pagePointer = -1;
            }
            else
            {
                pagePointer = historyList.Count - 1;
            }

            Console.WriteLine(pagePointer);
        }

        /// <summary>
        /// Add a HistoryItem to the hisotryList and updates the local hisotry to reflect this
        /// </summary>
        /// <param name="url">The URL to be added</param>
        public void addToHistory(string url)
        {
            pagePointer++;

            HistoryItem historyItem = new HistoryItem();
            historyItem.historyURL = url;
            historyItem.accessTime = DateTime.Now;
            historyList.Add(historyItem);

            saveHistoryLocally();

            OnHistoryUpdate(EventArgs.Empty);
        }

        /// <summary>
        /// Removes a HistoryItem from historyList and updates local history to reflect this 
        /// </summary>
        /// <param name="index">The index of the HistoryItem to be removed</param>
        public void deleteHistoryItem(int index)
        {
                historyList.RemoveAt(index);
                saveHistoryLocally();

                //This is handling an edge case of deletion ( if you delete the page you are on with only 1 other page)
                if (pagePointer > 1)
                {
                    pagePointer--;
                }

                OnHistoryUpdate(EventArgs.Empty);

        }

        /// <summary>
        /// Saves the current historylist to local storage
        /// </summary>
        public void saveHistoryLocally()
        {
            historyXMLManager.writeToXML(historyList, Resources.SearchHistory);
        }

        /// <summary>
        /// Loads the 
        /// </summary>
        /// <returns>A List<HistoryItem> containing the history items stored locally</returns>
        public List<HistoryItem> loadLocalHistory()
        {
            List<HistoryItem> list;
            list = historyXMLManager.readXMLToList(Resources.SearchHistory);

            return list;

        }

        /// <summary>
        /// Used to trigger an event in another class when the history is updated
        /// </summary>
        /// <param name="e">The args passed to the event</param>
        protected virtual void OnHistoryUpdate(EventArgs e)
        {
            EventHandler handler = historyItem;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
    /// <summary>
    /// Class used to represent the structure of a HistoryItem
    /// </summary>
    public class HistoryItem
    {
        public string historyURL { get; set; }
        public DateTime accessTime { get; set; }
    }

}