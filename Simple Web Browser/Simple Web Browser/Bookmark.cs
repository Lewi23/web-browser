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
        public static List<BookmarkItem> bookmarkList = new List<BookmarkItem>();

        XML<BookmarkItem> xml = new XML<BookmarkItem>();

        public Bookmark()
        {
            bookmarkList = loadLocalBookmarks();
        }

        public void loadBookmarks()
        {
            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void addBookmark(string bookmarkName, string bookmarkURL)
        {
            BookmarkItem bookmark = new BookmarkItem();
            bookmark.bookmarkName = bookmarkName;
            bookmark.bookmarkURL = bookmarkURL;
            bookmarkList.Add(bookmark);

            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void deleteBookmark(int index)
        {
            try
            {
                bookmarkList.RemoveAt(index);
                saveBookmarksLocally();
                OnBookmarkUpdate(EventArgs.Empty);
            } catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Error");
            }
            
        }
        
        public void editBookmark(int index, string bookmarkName, string bookmarkURL)
        {
            bookmarkList[index].bookmarkName = bookmarkName;
            bookmarkList[index].bookmarkURL = bookmarkURL;
            saveBookmarksLocally();
            OnBookmarkUpdate(EventArgs.Empty);
        }

        public void saveBookmarksLocally()
        {
            xml.writeToXML(bookmarkList, Resources.Bookmarks);
        }

        public List<BookmarkItem> loadLocalBookmarks()
        {
            List<BookmarkItem> list;
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

    public class BookmarkItem
    {
        public string bookmarkName { get; set; }
        public string bookmarkURL { get; set; }
    }
}
