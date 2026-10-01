using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Data
{
    public class UserRepository
    {
        private List<User> _users { get; set; } = new List<User>();
        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }

        public User? UpdateUser(Guid id, string firstName, string lastName)
        {
            var userExists = _users.FirstOrDefault(u => u.Id == id);
            if (userExists != null)
            {
                userExists.FirstName = firstName;
                userExists.LastName = lastName;
                _users.Remove(userExists);
                _users.Add(userExists);
                return userExists;
            }
            else
            {
                return null;
            }
        }

        public User? DeleteUser(Guid id)
        {
            var removeUser=_users.FirstOrDefault(u => u.Id == id);
            if (removeUser != null)
            {
                _users.Remove(removeUser);
            }
            return removeUser;
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
