using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please write your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please write your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please write your Phone")]
        public string Phone { get; set; }
        public AddressModel Address { get; set; }
    }
}
