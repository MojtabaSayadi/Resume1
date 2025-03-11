using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.domain.Models.Auth;

namespace Resume1.domain.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        bool IsExist(int Id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
        void Delete(User user);
        void Save();
    }
}
