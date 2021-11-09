using Address_book.DataAccess.Interfaces;
using Address_book.Entity;
using Address_book.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.DataAccess.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Address> _addressRepository;

        public ContactService(IRepository<Contact> contactRepository, IRepository<Address> addressRepository)
        {
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
        }

        public Contact CreateContact(Contact contact)
        {
            var addressId = Guid.Empty;
            if (contact.Address != null)
                addressId = _addressRepository.Add(contact.Address).Id;

            contact.AddressId = addressId;
            var result = _contactRepository.Add(contact);

            _contactRepository.Save();

            return result;

        }

        public void DeleteContact(Guid id)
        {
            var result = _contactRepository.GetById(id);
            if (result != null)
            {
                _contactRepository.Remove(id);
                _contactRepository.Save();
            }
            else
            {
                throw new Exception("Contact not found");
            }
        }

        public Contact EditContact(Contact contact)
        {
            var oldContactValues = _contactRepository.Get().Include(o => o.Address).ToList().FirstOrDefault(o => o.Id == contact.Id);

            if (oldContactValues != null)
            {
                oldContactValues.Name = contact.Name;
                oldContactValues.Email = contact.Email;
                oldContactValues.Phone = contact.Phone;
                if (oldContactValues.AddressId != Guid.Empty)
                {
                    var address = _addressRepository.GetById(oldContactValues.AddressId);
                    address.HomeNumber = contact.Address.HomeNumber;
                    address.City = contact.Address.City;
                    address.Country = contact.Address.Country;
                    address.Street = contact.Address.Street;
                    _addressRepository.Update(address);
                }
                _contactRepository.Update(oldContactValues);
                _contactRepository.Save();
                var result = _contactRepository.GetById(contact.Id);
                return result;
            }
            else
            {
                throw new Exception("Contact not found");
            }
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            var result = _contactRepository.Get().Include(o => o.Address).ToList();

            if (result != null)
            {
                    return result;
            }
            else 
                return new List<Contact>();
        }

        public Contact GetContactById(Guid id)
        {
            Contact result = _contactRepository.GetById(id);
            if (result == null)
             throw new Exception("Contact not found");

            var address = _addressRepository.GetById(result.AddressId);
            result.Address = address;

            return result;
        }
    }
}
