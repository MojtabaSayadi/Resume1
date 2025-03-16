using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Resume1.Data.Migrations;
using Resume1.domain.Models.Auth;

namespace Resume1.core.Services.Interfaces
{
    public interface IAddressService
    {
        Address GetAddressById(int id);
        List<Address> GetAddress();
        List<Address> GetAllByUserId(int id);
        bool IsExist(int Id);
        void AddAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(int id);
        void DeleteAddress(Address address);
        void SaveAddress();
    }
}
