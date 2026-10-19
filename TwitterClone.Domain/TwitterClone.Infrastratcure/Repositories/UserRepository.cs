using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Data
{
    public class UserRepository:IUserRepository
    {
        private List<User> _users { get; set; } = new List<User>();
        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public User? UpdateUser(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);
            return user;
        }

        public bool DeleteUser(User user)
        {
            var removeUser=_users.FirstOrDefault(u => u.Id == user.Id);
            if (removeUser != null)
            {
                _users.Remove(removeUser);
                return true;
            }
            return false; 
        }

        public List<User> ShowUsers()
        {
            return _users;
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
