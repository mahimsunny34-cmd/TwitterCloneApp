using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetService
    {
        List<ReadRetweetDto> GetRetweets();
        ReadRetweetDto? CreateRetweet(CreateRetweetDto createRetweetDto);
        ReadRetweetDto? GetRetweetById(Guid id);
        ReadRetweetDto? UpdateRetweet(Guid id, UpdateRetweetDto dto);
        bool DeleteRetweet(Guid id);
    }
}
