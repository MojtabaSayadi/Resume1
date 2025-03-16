using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.domain.Models.Auth;

namespace Resume1.domain.Interfaces
{
    public interface IAddressRepository
    {
        Address GetById(int id);
        List<Address> GetAll();
        List<Address> GetAllByUserId(int UserId);
        bool IsExist(int Id);
        void Add(Address address);
        void Update(Address address);
        void Delete(int id);
        void Delete(Address  address);
        void Save();
    }
}
