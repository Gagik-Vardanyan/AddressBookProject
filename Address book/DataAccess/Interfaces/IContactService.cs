using Address_book.Entity;
using Address_book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.DataAccess.Interfaces
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(Guid id);
        Contact CreateContact(Contact contact);
        void DeleteContact(Guid id);
        Contact EditContact(Contact contact);
    }
}
