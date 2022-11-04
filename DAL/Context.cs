using Microsoft.EntityFrameworkCore;

using DAL.Entities;
using System.Reflection.Metadata;

namespace DAL
{
    internal class Context: DbContext
    {
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Book>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Client>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Genre>()
                .Property(b => b.CreateAt)
                .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Author>()
              //  .Property(b => b.FullName)
                //.HasDefaultValueSql("[FirstName] + ' ' + [MiddleName] + ' ' + [LastName]");
        }
    }
}
