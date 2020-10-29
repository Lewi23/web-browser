using Simple_Web_Browser.Properties;
using System;
using System.Collections.Generic;

namespace Simple_Web_Browser
{
    /// <summary>
    /// This class is responsible for managing the bookmarks for the web browser
    /// </summary>
    public class Bookmark
    {

        public event EventHandler bookmarkItem;
        public static List<BookmarkItem> bookmarkList;
        XML<BookmarkItem> bookmarkXMLManager = new XML<BookmarkItem>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Bookmark()
        {
            bookmarkList = new List<BookmarkItem>();
        }

        /// <summary>
        /// Loads bookmarks from local storage
        /// </summary>
        public void loadBookmarks()
        {
            bookmarkList = loadLocalBookmarks();
            OnBookmarkUpdate(EventArgs.Empty);
        }

        /// <summary>
        /// Adds a bookmark to the bookmarkList
        /// </summary>
        /// <param name="bookmarkName">The bookmark name</param>
        /// <param name="bookmarkURL">The bookmark URL</param>
        public void addBookmark(string bookmarkName, string bookmarkURL)
        {
            BookmarkItem bookmark = new BookmarkItem();
            bookmark.bookmarkName = bookmarkName;
            bookmark.bookmarkURL = bookmarkURL;
            bookmarkList.Add(bookmark);

            OnBookmarkUpdate(EventArgs.Empty);
        }

        /// <summary>
        /// Deletes a bookmark from bookmarkList
        /// </summary>
        /// <param name="index">The index of the bookmarkItem to be removed</param>
        public void deleteBookmark(int index)
        {
                bookmarkList.RemoveAt(index);
                saveBookmarksLocally();
                OnBookmarkUpdate(EventArgs.Empty);
        }
        
        /// <summary>
        /// Edits the selected bookmark with the new bookmark name and URL paramters provided
        /// Updates the locally stored bookmarks
        /// </summary>
        /// <param name="index">The index of the bookmark</param>
        /// <param name="bookmarkName">The new bookmark name</param>
        /// <param name="bookmarkURL">The new bookmark URL </param>
        public void editBookmark(int index, string bookmarkName, string bookmarkURL)
        {
                bookmarkList[index].bookmarkName = bookmarkName;
                bookmarkList[index].bookmarkURL = bookmarkURL;
                saveBookmarksLocally();
                OnBookmarkUpdate(EventArgs.Empty);

        }

        /// <summary>
        /// Saves the bookmarkList to local storage
        /// </summary>
        public void saveBookmarksLocally()
        {
            bookmarkXMLManager.writeToXML(bookmarkList, Resources.Bookmarks);
        }

        /// <summary>
        /// Loads the bookmarks stored in local storage into a list
        /// </summary>
        /// <returns>Local bookmarks in a List<BookmarkItem></returns>
        public List<BookmarkItem> loadLocalBookmarks()
        {
            List<BookmarkItem> list;
            list = bookmarkXMLManager.readXMLToList(Resources.Bookmarks);

            return list; 

        }

        /// <summary>
        /// Used to trigger an event in another class when the bookmarks are updated
        /// </summary>
        /// <param name="e">The args passed to the event</param>
        protected virtual void OnBookmarkUpdate(EventArgs e)
        {
            EventHandler handler = bookmarkItem;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    /// <summary>
    /// Class used to represent the structure of a BookmarkItem
    /// </summary>
    public class BookmarkItem
    {
        public string bookmarkName { get; set; }
        public string bookmarkURL { get; set; }
    }
}
