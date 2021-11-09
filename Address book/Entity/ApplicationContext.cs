using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.Entity
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Contact>().Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<Contact>().Property(e => e.Email).IsRequired();

            modelBuilder.Entity<Contact>()
                .HasOne<Address>(g => g.Address)
                .WithMany(s => s.Contacts)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasMany<Contact>(g => g.Contacts)
                .WithOne(s => s.Address)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
