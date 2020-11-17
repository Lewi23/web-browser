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
        Manager manager;

        [TestInitialize]
        public void Setup()
        {
            historyManager = new History();
            manager = new Manager();
            manager.buildJSONFiles();
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
            try
            {
                historyManager.addToHistory("https://www.google.com/");
                historyManager.addToHistory("https://www.google.com/");

                historyManager.deleteHistoryItem(int.MaxValue);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

        }

        [TestMethod]
        public void delete_when_history_is_empty()
        {
            try
            {
                historyManager.deleteHistoryItem(int.MaxValue);
                Assert.Fail();
            } catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

            
        }

    }
}
