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
    public class AddressRepository : IAddressRepository

    {
        private Resume1Context context;

        public AddressRepository(Resume1Context _context)
        {
            context = _context;
        }
        public void Add(Address address)
        {
           context.addresses.Add(address);
        }

        public void Delete(int id)
        {
            context.addresses.Remove(GetById(id));
        }

        public void Delete(Address address)
        {
            context.addresses.Remove(address);
        }

        public List<Address> GetAll()
        {
            return context.addresses.ToList();
        }

        public List<Address> GetAllByUserId(int UserId)
        {
            return context.addresses.Where(p =>p.UserId==UserId).ToList();
        }

        public Address GetById(int id)
        {
            return context.addresses.Find(id);   
        }

        public bool IsExist(int Id)
        {
            return context.addresses.Any(a => a.Id == Id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Address address)
        {
            context.Update(address);
        }
    }
}
