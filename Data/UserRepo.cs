using System.Collections.Generic;
using user_service.Models;

namespace user_service.Data
{
    public class UserRepo : IUserRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> getAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CreateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            throw new System.NotImplementedException();
        }
    }
}