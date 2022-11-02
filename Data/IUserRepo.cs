using System.Collections.Generic;
using user_service.Models;

namespace user_service.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> getAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);

        User GetUserByAuth0Id(string auth0Id);
    }
}