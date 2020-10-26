using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Web_Browser;

namespace Simple_Web_Browser_Tests
{
    [TestClass]
    public class HistoryTests
    {

        History historyManager;

       [TestInitialize]
        public void Setup()
        {
            historyManager = new History();
        }

        [TestMethod]
        public void can_step_back_true()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 1;

            Assert.AreEqual(true, historyManager.canStepBack());

        }

        [TestMethod]
        public void can_step_back_false()
        {
            Assert.AreEqual(false, historyManager.canStepBack());
        }

        [TestMethod]
        public void can_step_forward_true()
        {
            HistoryItem item1 = new HistoryItem();
            HistoryItem item2 = new HistoryItem();
            History.historyList.Add(item1);
            History.historyList.Add(item2);

            History.pagePointer = 0;

            Assert.AreEqual(true, historyManager.canStepForward());
        }

        [TestMethod]
        public void can_step_forward_false()
        {
            Assert.AreEqual(false, historyManager.canStepForward());
        }

        [TestMethod]
        public void add_to_history()
        {

            historyManager.addToHistory("https://www.google.com/");

            Assert.AreEqual(1, History.historyList.Count);

        }

        [TestMethod]
        public void add_empty_string_to_history()
        {

            historyManager.addToHistory("");

            Assert.AreEqual(1, History.historyList.Count);

        }

        [TestMethod]
        public void add_null_to_history()
        {

            historyManager.addToHistory(null);

            Assert.AreEqual(1, History.historyList.Count);

        }

        [TestMethod]
        public void delete_history_item()
        {

            historyManager.addToHistory("https://www.google.com/");
            historyManager.addToHistory("https://www.google.com/");

            historyManager.deleteHistoryItem(1);

            Assert.AreEqual(1, History.historyList.Count);
        }

        [TestMethod]
        public void delete_history_out_of_range()
        {
            historyManager.addToHistory("https://www.google.com/");
            historyManager.addToHistory("https://www.google.com/");

            historyManager.deleteHistoryItem(int.MaxValue);
        }

        [TestMethod]
        public void delete_when_history_is_empty()
        {
            historyManager.deleteHistoryItem(int.MaxValue);
        }

        [TestMethod]
        public void persistent_history()
        {
            historyManager.addToHistory("https://www.google.com/");
            historyManager.addToHistory("https://www.google.com/");

            // Save our two local history items to persistent storage
            historyManager.saveHistoryLocally();

            // Overwrite our current in memory history list
            History.historyList = new List<HistoryItem>();

            // Reload history from persistent storage
            History.historyList = historyManager.loadLocalHistory();

            // Checking that historyList has the two elements we added earlier
            Assert.AreEqual(2, History.historyList.Count);

        }



    }
}
