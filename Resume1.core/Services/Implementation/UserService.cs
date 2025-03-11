using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.core.Services.Interfaces;
using Resume1.domain.Interfaces;
using Resume1.domain.Models.Auth;

namespace Resume1.core.Services.Implementation
{
    public class UserService : IUserService
    {
        private  IUserRepository userRpository;
        public UserService(IUserRepository _userRepository) 
        {
            userRpository = _userRepository;
        }
        public void AddUser(User user)
        {
           userRpository.Add(user);
            SaveUser();
        }

        public void DeleteUser(int id)
        {
            userRpository?.Delete(id);
            SaveUser();
        }

        public void DeleteUsers(User user)
        {
            userRpository.Delete(user);
            SaveUser();
        }

        public User GetUserById(int id)
        {
          return  userRpository.GetById(id);
        }

        public List<User> GetUsers()
        {
            return userRpository.GetAll();
        }

        public bool IsExist(int Id)
        {
            return userRpository.IsExist(Id);
        }

        public void SaveUser()
        {
            userRpository.Save();
        }

        public void UpdateUser(User user)
        {
            userRpository.Update(user);
            SaveUser();
        }
    }
}
