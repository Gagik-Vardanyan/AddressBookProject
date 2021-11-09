using Address_book.DataAccess.Interfaces;
using Address_book.Entity;
using Address_book.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;  
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var contacts = _contactService.GetAllContacts().ToList();

            var contactModels = new List<ContactModel>();
            contacts.ForEach(c => contactModels.Add(_mapper.Map<ContactModel>(c)));

            return View(contactModels);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var contact = _contactService.GetContactById(id);
            return View(_mapper.Map<ContactModel>(contact));
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        { 
            _contactService.EditContact(_mapper.Map<Contact>(contact));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactService.CreateContact(_mapper.Map<Contact>(contact));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SingleContact(Guid Id)
        {
            var contact = _contactService.GetContactById(Id);
            return View(_mapper.Map<ContactModel>(contact));
        }
       
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _contactService.DeleteContact(id);

            return RedirectToAction("Index");
        }
    }
}