using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.Data.Context;
using Resume1.domain.Interfaces;
using Resume1.domain.Models.Auth;

namespace Resume1.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Resume1Context context;

        public UserRepository(Resume1Context _context) 
        {
            context = _context;
        }
        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Delete(int id)
        {
            context.Users.Remove(GetById(id));
        }

        public void Delete(User user)
        {
           context.Remove(user);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList(); 
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);

        }

        public bool IsExist(int Id)
        {
           return context.Users.Any(u => u.Id == Id);
        }

        public void Save()
        {
            //context.Update(context.Users);
            context.SaveChanges();

        }

        public void Update(User user)
        {
            context.Update(user);
        }
    }
}
