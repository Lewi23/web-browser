using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple_Web_Browser;

namespace Simple_Web_Browser_Tests
{
    [TestClass]
    public class HistoryTests
    {
        string initalURL = "https://www.google.com/";


        [TestMethod]
        public void getPreviousPage_outOfRange()
        {
            History history_outOfRange = new History(initalURL);
           //  Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => history_outOfRange.goBack());
        }

        [TestMethod]
        public void getNextPage_outOfRange()
        {
            History history_outOfRange = new History(initalURL);
           // Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => history_outOfRange.goForward());

        }

        [TestMethod]
        public void loadPage()
        {
            History add = new History(initalURL);
            add.addToHistory("https://www.reddit.com/");

            Assert.AreEqual(2, History.item.Count);
            
        }

      
        
    }
}
