using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class FollowRepository:IFollowRepository
    {
        private readonly List<Follow> _follows=new List<Follow>();
        public Follow? AddFollow(Follow follow)
        {
            _follows.Add(follow);
            return follow;
        }

        public List<Follow> ShowAllFollows()
        {
            return _follows;
        }

        public Follow? GetFollowById(Guid id)
        {
            var followsExists=_follows.SingleOrDefault(f=>f.Id == id);
            if (followsExists == null)
            {
                return null;
            }
            return followsExists;
        }

        public bool DeleteFollow(Guid id)
        {
            var followExists = _follows.SingleOrDefault(f => f.Id == id);
            if (followExists == null)
            {
                return false;
            }
            _follows.Remove(followExists);
            return true;
        }

        public List<Follow>? Followers(Guid id)
        {
            var users= _follows.Where(f => f.FollowingId == id).ToList();
            return users;
        }
        public List<Follow>? Following(Guid id)
        {
            var users = _follows.Where(f => f.FollowerId == id).ToList();
            return users;
        }
    }
}
