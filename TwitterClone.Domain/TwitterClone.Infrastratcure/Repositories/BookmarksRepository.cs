using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class BookmarksRepository :IBookmarkRepository
    {
        private readonly List<Bookmark> _bookmarks = new List<Bookmark>();
        public Bookmark? AddBookmark(Bookmark bookmark)
        {
            _bookmarks.Add(bookmark);
            return bookmark;
        }

        public List<Bookmark> ShowBookmarks()
        {
            return _bookmarks;
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            var bookmarkExists = _bookmarks.SingleOrDefault(b => b.Id == id);
            if (bookmarkExists == null)
            {
                return null;
            }
            return bookmarkExists;
        }

        public Bookmark? UpdateBookmark(Bookmark bookmark)
        {
            _bookmarks.RemoveAll(b => b.Id == bookmark.Id);
            _bookmarks.Add(bookmark);
            return bookmark;
        }

        public bool DeleteBookmark(Guid id)
        {
            var bookmarkExists = _bookmarks.SingleOrDefault(b => b.Id == id);
            if (bookmarkExists == null)
            {
                return false;
            }
            _bookmarks.Remove(bookmarkExists);
            return true;
        }
    }
}
