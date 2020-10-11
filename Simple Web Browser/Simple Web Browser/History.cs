﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Web_Browser
{
    public class History
    {

        // History stuff
        // back and forward buttons
        public static List<string> item = new List<string>();
        static public int index = 0;

        static string url = "";

        public bool CanStepBack = item.ElementAtOrDefault(index - 1) != null ? true : false;
        public bool CanStepForward = item.ElementAtOrDefault(index + 1) != null ? true : false;
        public bool addedURL;

        // List of items used to display the history list
        public List<HistoryItemArgs> HistoryList = new List<HistoryItemArgs>();

        public History()
        {
        }

        public void setIndex(int n)
        {
            // this fixed it
            index = n + 1;
        }
       

        public History(string initalURI)
        {
            //item.Add(initalURI);
            addToHistory(initalURI);
            url = initalURI;

            Console.Write("Inital item count: {0}", item.Count);
        }

        public string historyURL(int index)
        {
            System.Console.WriteLine("returning {0}", item[index]);
            return item[index];
        }

        public string getNextPage()
        {
                
                index++;
            Console.WriteLine("INDEX : {0} ", index);
                Console.WriteLine("Returning {0} at index {1}", item[index], index);
                return item[index];
        }

        
        public string getPreviousPage()
        {

            index = index - 1;
            Console.WriteLine("INDEX : {0} ", index);
            Console.WriteLine("Returning {0} at index {1}", item[index], index);
                return item[index];
   
        }

        public void printAllItem()
        {
            System.Console.WriteLine(item.Count);

            foreach (string x in item)
            {
                System.Console.WriteLine(x);
            }
        }

        public void removeAt(int index)
        {
            // removing from history only, not back and forward
            HistoryList.RemoveAt(index);
        }
        
        public void addToHistory(string URL)
        {
            //if(item[item.Count - 1] == URL)
            //{
            //}
            // don't add an element to history if the same URL is trying to be added again 
            //if(item.ElementAt(item.Count -1) != URL)
            //{
            Console.WriteLine("Added to history is being called");

                index++;
                item.Add(URL);
                //URLS.Add(URL);
                //addedURL = true;

                HistoryItemArgs args = new HistoryItemArgs();
                args.pageURL = URL;
                args.CurrentTime = DateTime.Now;
                OnHistoryItem(args);
            

            //} else
            //{
            //    addedURL = false;
            //}

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

    }
    
    public class HistoryItemArgs : EventArgs
    {
        public string pageURL { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
