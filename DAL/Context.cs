using Microsoft.EntityFrameworkCore;

using DAL.Entities;

namespace DAL
{
    internal class Context : DbContext
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

        public virtual DbSet<Form> Forms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=library;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(entity => entity.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Book>()
                .Property(entity => entity.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Client>()
                .Property(entity => entity.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Genre>()
                .Property(entity => entity.CreateAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Form>()
                .Property(entity => entity.CreateAt)
                .HasDefaultValueSql("getdate()");
        }
    }
}
