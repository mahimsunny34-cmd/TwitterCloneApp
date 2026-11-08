using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class FollowService:IFollowService
    {
        private readonly IFollowRepository _followRepo;
        private readonly IUserRepository _userRepo;
        public FollowService(IFollowRepository followRepo, IUserRepository userRepo)
        {
            _followRepo = followRepo;
            _userRepo = userRepo;
        }

        public FollowDto? AddFollow(FollowDto followDto)
        {
            if(Guid.Empty==followDto.FollowerId || Guid.Empty == followDto.FollowingId)
            {
                return null;
            }
            var newFollow=new Follow(followDto.FollowerId, followDto.FollowingId);
            var addedFollow = _followRepo.AddFollow(newFollow);
            return new FollowDto
            {
                FollowerId= addedFollow.FollowerId,
                FollowingId = addedFollow.FollowingId
            };
        }
        public List<FollowDto> ShowFollowers(Guid userId)
        {
            if(userId== Guid.Empty)
            {
                return null;
            } 
            var userExists=_userRepo.GetUserById(userId);
            if(userExists == null)
            {
                return null;
            }

            var followers = _followRepo.Followers(userId).Select(f => new FollowDto
            {
                FollowerId = f.FollowerId,
            }).ToList();
            return followers;
        }
        public FollowDto? GetFollowById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
            var follow = _followRepo.GetFollowById(id);
            if (follow == null)
            {
                return null;
            }
            return new FollowDto
            {
                FollowerId = follow.FollowerId,
                FollowingId = follow.FollowingId
            };
        }
        public List<FollowDto> ShowAllFollowing(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return null;
            }
            var userExists = _userRepo.GetUserById(userId);
            if (userExists == null)
            {
                return null;
            }

            var following=_followRepo.Following(userId).Select(f=>new FollowDto
            {
                FollowingId = f.FollowingId
            }).ToList();
            return following;
        }
        public FollowDto CreateFollow(FollowDto followDto)
        {
            if(followDto.FollowerId == Guid.Empty || followDto.FollowingId == Guid.Empty)
            {
                return null;
            }

            var newFollow = new Follow(followDto.FollowerId, followDto.FollowingId);
            var follow= _followRepo.AddFollow(newFollow);
            return new FollowDto
            {
                FollowerId = follow.FollowerId,
                FollowingId = follow.FollowingId
            };
        }
        public bool DeleteFollow(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }

            var unfollow=_followRepo.DeleteFollow(id);
            return unfollow;
        }
    }
}
