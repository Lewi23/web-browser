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
            bookmarkList = loadLocalHisotry();
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
            saveToLocalHistory();
            OnBookmarkUpdate(EventArgs.Empty);
        }
        
        public void editBookmark(int index, string bookmarkName, string bookmarkURL)
        {
            bookmarkList[index].bookmarkName = bookmarkName;
            bookmarkList[index].bookmarkURL = bookmarkURL;
            saveToLocalHistory();
            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void saveToLocalHistory()
        {
            xml.writeListToXML(bookmarkList, Resources.Bookmarks);
        }

        public List<BookmarkArgs> loadLocalHisotry()
        {
            List<BookmarkArgs> list;
            list = xml.readXMLToList(Resources.Bookmarks);

            return list;

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
