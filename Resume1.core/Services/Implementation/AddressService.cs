using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resume1.core.Services.Interfaces;
using Resume1.Data.Repositories;
using Resume1.domain.Interfaces;
using Resume1.domain.Models.Auth;

namespace Resume1.core.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private IAddressRepository   addressRepository;
        public AddressService(IAddressRepository _addressRepository)
        {
            addressRepository = _addressRepository;
        }

        public void AddAddress(Address address)
        {
            addressRepository.Add(address);
            addressRepository.Save();
        }

        public void DeleteAddress(int id)
        {
            addressRepository.Delete(GetAddressById(id));
            addressRepository.Save();
        }

        public void DeleteAddress(Address address)
        {
            addressRepository.Delete(address);
            addressRepository.Save();
        }

        public List<Address> GetAddress()
        {
            return addressRepository.GetAll();
        }

        public Address GetAddressById(int id)
        {
            return addressRepository.GetById(id);
        }

        public List<Address> GetAllByUserId(int id)
        {
            return addressRepository.GetAllByUserId(id);
        }

        public bool IsExist(int Id)
        {
            return addressRepository.IsExist(Id);
        }

        public void Save()
        {
            addressRepository.Save();
        }

        public void SaveAddress()
        {
            addressRepository.Save();
        }

        public void UpdateAddress(Address address)
        {
            addressRepository.Update(address);
            addressRepository.Save();
        }
    }
}
