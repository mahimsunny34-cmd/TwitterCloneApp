using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class BookmarkService : IBookmarkService
    {
        public IBookmarkRepository _bookmarkRepository;
        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }
        public ReadBookmarkDto? CreateBookmark(CreateBookmarkDto createBookmarkDto)
        {
            if(createBookmarkDto.UserId==Guid.Empty || createBookmarkDto.TweetId == Guid.Empty)
            {
                return null;
            }
            var newBookmark = new Bookmark(createBookmarkDto.UserId, createBookmarkDto.TweetId);
            var bookmark = _bookmarkRepository.AddBookmark(newBookmark);
            return new ReadBookmarkDto
            {
                AuthorId = bookmark.UserId,
                TweetId = bookmark.TweetId
            };
        }

        public List<ReadBookmarkDto> GetBookmarks()
        {
            var bookmarks = _bookmarkRepository.ShowBookmarks();
            var bookmarksDto=bookmarks.Select(b=>new ReadBookmarkDto
            {
                AuthorId = b.UserId,
                TweetId = b.TweetId
            }).ToList();
            return bookmarksDto;
        }

        public ReadBookmarkDto? GetBookmarkById(Guid id)
        {
            var bookmark=_bookmarkRepository.GetBookmarkById(id);
            if (bookmark == null)
            {
                return null;
            }

            return new ReadBookmarkDto
            {
                AuthorId = bookmark.UserId,
                TweetId = bookmark.TweetId
            };
        }

        public ReadBookmarkDto? UpdateBookmark(Guid id, UpdateBookmarkDto updateBookmarkDto)
        {
            var bookmarkExists = _bookmarkRepository.GetBookmarkById(id);
            if (bookmarkExists == null)
            {
                return null;
            }
            var bookmark = _bookmarkRepository.UpdateBookmark(bookmarkExists);
            return new ReadBookmarkDto
            {
                AuthorId = bookmark.UserId,
                TweetId = bookmark.TweetId
            };
        }

        public bool DeleteBookmark(Guid id)
        {
            var deleteBookmark = _bookmarkRepository.DeleteBookmark(id);
            return deleteBookmark;
        }
    }
}
