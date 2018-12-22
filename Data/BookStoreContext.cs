using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext (DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Configurations
                .Add(new UserConfiguration())
                .Add(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public class OrderConfiguration :
        {
            public UserConfiguration()
            {
                HasKey(c => c.Id);
                Property(c => c.Id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                HasMany(t => t.Roles)
                    .WithMany(t => t.Users)
                    .Map(m =>
                    {
                        m.ToTable("UserRole");
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                    });
            }
        }
        public DbSet<BookStore.Models.Book> Book { get; set; }

        public DbSet<BookStore.Models.Cart> Cart { get; set; }

        public DbSet<BookStore.Models.Order> Order { get; set; }

        public DbSet<BookStore.Models.User> User { get; set; }
    }
}
