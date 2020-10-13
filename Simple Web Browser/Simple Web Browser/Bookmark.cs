using Simple_Web_Browser.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Simple_Web_Browser
{
    public class Bookmark
    {

        public event EventHandler bookmarkItem;
        public static List<BookmarkArgs> bookmarkList = new List<BookmarkArgs>();

        XML<BookmarkArgs> xml = new XML<BookmarkArgs>();

        public Bookmark()
        {
        
        }

        public void loadBookmarks()
        {
            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void addBookmark(string bookmarkName, string bookmarkURL)
        { 
            BookmarkArgs bookmark = new BookmarkArgs();
            bookmark.bookmarkName = bookmarkName;
            bookmark.bookmarkURL = bookmarkURL;
            bookmarkList.Add(bookmark);

            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void deleteBookmark(int index)
        {
            bookmarkList.RemoveAt(index);
            OnBookmarkUpdate(EventArgs.Empty);
        }
        
        public void editBookmark(int index, string bookmarkName, string bookmarkURL)
        {
            bookmarkList[index].bookmarkName = bookmarkName;
            bookmarkList[index].bookmarkURL = bookmarkURL;
            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void saveLocal()
        {
            xml.writeListToXML(bookmarkList, Resources.Bookmarks);
        }

        public void readXML()
        {
            List<BookmarkArgs> list;
            list = xml.readXMLToList(Resources.Bookmarks);

            foreach(BookmarkArgs bookmark in list)
            {
                Console.WriteLine(bookmark.bookmarkName);
                Console.WriteLine(bookmark.bookmarkURL);
            }
        }

        protected virtual void OnBookmarkUpdate(EventArgs e)
        {
            EventHandler handler = bookmarkItem;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class BookmarkArgs 
    {
        public string bookmarkName { get; set; }
        public string bookmarkURL { get; set; }
    }
}
