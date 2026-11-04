using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastratcure.Persistance;

namespace TwitterClone.API.Data
{
    public class UserRepository:IUserRepository
    {
        private List<User> _users { get; set; } = new List<User>();
        private readonly TwitterCloneDbContext _dbContext;
        public UserRepository(TwitterCloneDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User? UpdateUser(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            var existingUser = _dbContext.Users.Find(user.Id);
            if (existingUser != null)
            {
                _dbContext.Users.Remove(existingUser);
                _dbContext.SaveChanges();
            }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public bool DeleteUser(User user)
        {
            var removeUser= _dbContext.Users.SingleOrDefault(u => u.Id == user.Id);
            if (removeUser != null)
            {
                _dbContext.Users.Remove(removeUser);
                _dbContext.SaveChanges();
                return true;
            }
            return false; 
        }

        public List<User> ShowUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User? GetUserById(Guid id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
