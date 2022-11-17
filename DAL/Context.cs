using Microsoft.EntityFrameworkCore;

using DAL.Entities;
using DAL.UnitsOfWork;

namespace DAL
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            var client = new DAL.Entities.Client()
            {
                FirstName = "Ivan",
                MiddleName = "Ivanovych",
                LastName = "Ivanov",
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                    {
                        new DAL.Entities.Book()
                        {
                            Name = "Aa",
                            Author = new DAL.Entities.Author()
                            {
                                FirstName = "Ivan",
                                MiddleName = "Ivanovych",
                                LastName = "Ivanov"
                            },
                            Genre = new DAL.Entities.Genre()
                            {
                                Name = "Genre"
                            }
                        }
                    }
                }
            };

            var client1 = new DAL.Entities.Client()
            {
                FirstName = "Ivan",
                MiddleName = "Ivanovych",
                LastName = "Ivanov",
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                    {
                        new DAL.Entities.Book()
                        {
                            Name = "Aa",
                            Author = new DAL.Entities.Author()
                            {
                                FirstName = "Ivan",
                                MiddleName = "Ivanovych",
                                LastName = "Ivanov"
                            },
                            Genre = new DAL.Entities.Genre()
                            {
                                Name = "Genre"
                            }
                        }
                    }
                }
            };

            Clients.Add(client);
            SaveChanges();
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
