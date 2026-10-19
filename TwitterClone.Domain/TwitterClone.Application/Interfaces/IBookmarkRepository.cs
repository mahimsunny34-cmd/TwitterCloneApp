using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkRepository
    {
        Bookmark? AddBookmark(Bookmark bookmark);
        List<Bookmark> ShowBookmarks();
        Bookmark? GetBookmarkById(Guid id);
        Bookmark? UpdateBookmark(Bookmark bookmark);
        bool DeleteBookmark(Guid id);
    }
}
