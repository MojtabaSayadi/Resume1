using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.domain.Models.Auth;

namespace Resume1.core.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        List<User> GetUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void DeleteUsers(User user);
        void SaveUser();
    }
}
