using Address_book.Entity;
using Address_book.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.Infrastructure
{
    public class ConfigurationAutoMapper : Profile
    {
        public ConfigurationAutoMapper()
        {
            CreateMap<Contact, ContactModel>();

            CreateMap<ContactModel, Contact>();

            CreateMap<Address, AddressModel>();

            CreateMap<AddressModel, Address>();
        }
    }
}
