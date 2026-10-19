using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkService
    {
        ReadBookmarkDto? CreateBookmark(CreateBookmarkDto createBookmarkDto);
        List<ReadBookmarkDto> GetBookmarks();
        ReadBookmarkDto? GetBookmarkById(Guid id);
        ReadBookmarkDto? UpdateBookmark(Guid id, UpdateBookmarkDto updateBookmarkDto);
        bool DeleteBookmark(Guid id);
    }
}
