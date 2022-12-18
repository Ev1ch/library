using Microsoft.EntityFrameworkCore;

using DAL.Entities;
using DAL.Entities.Relations;

namespace DAL
{
    public class Context : DbContext
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildDateFields(modelBuilder);
            BuildDefaultFields(modelBuilder);
            BuildRelations(modelBuilder);

            modelBuilder.Entity<Client>().HasData(new DAL.Entities.Client()
             {
                 Id = 1,
                 FirstName = "Ivan",
                 MiddleName = "Ivanovych",
                 LastName = "Ivanov",
             });
             modelBuilder.Entity<Author>().HasData(new DAL.Entities.Author()
             {
                 Id = 1,
                 FirstName = "Ivan",
                 MiddleName = "Ivanovych",
                 LastName = "Ivanov"
             }
             );
             modelBuilder.Entity<Genre>().HasData(new DAL.Entities.Genre()
             {
                 Id = 1,
                 Name = "Genre"
             }
             );
             modelBuilder.Entity<Book>().HasData(new DAL.Entities.Book()
             {
                 Id = 1,
                 Name = "Aa",
                 Available = 1,
                 Quantity = 2,
             });
             modelBuilder.Entity<AuthorBook<int, int>>().HasData(new AuthorBook<int, int>{AuthorId = 1, BookId = 1});
             modelBuilder.Entity<BookGenre<int, int>>().HasData(new BookGenre<int, int>{BookId = 1, GenreId = 1});
             modelBuilder.Entity<Form>().HasData(new DAL.Entities.Form()
             {
                 Id = 1,
                 ClientId = 1,
             });
             modelBuilder.Entity<FormBook<int, int>>().HasData(new FormBook<int, int> { FormId = 1, BookId = 1 });
        }

        protected void BuildRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.Genres)
                .WithMany(genre => genre.Books)
                .UsingEntity<BookGenre<int, int>>(
                    j => j
                        .HasOne(pt => pt.Genre)
                        .WithMany(t => t.BookGenres)
                        .HasForeignKey(pt => pt.GenreId),
                    j => j
                        .HasOne(pt => pt.Book)
                        .WithMany(p => p.BookGenres)
                        .HasForeignKey(pt => pt.BookId),
                    j =>
                    {
                        j.HasKey(t => new { t.BookId, t.GenreId });
                    });

            modelBuilder.Entity<Author>()
                .HasMany(author => author.Books)
                .WithMany(book => book.Authors)
                .UsingEntity<AuthorBook<int, int>>(
                    j => j
                        .HasOne(pt => pt.Book)
                        .WithMany(t => t.AuthorBooks)
                        .HasForeignKey(pt => pt.BookId),
                    j => j
                        .HasOne(pt => pt.Author)
                        .WithMany(p => p.AuthorBooks)
                        .HasForeignKey(pt => pt.AuthorId),
                    j =>
                    {
                        j.HasKey(t => new { t.AuthorId, t.BookId });
                    });

            modelBuilder.Entity<Form>()
                .HasMany(form => form.Books)
                .WithMany(book => book.Forms)
                .UsingEntity<FormBook<int, int>>(
                    j => j
                        .HasOne(pt => pt.Book)
                        .WithMany(t => t.FormBooks)
                        .HasForeignKey(pt => pt.BookId),
                    j => j
                        .HasOne(pt => pt.Form)
                        .WithMany(p => p.FormBooks)
                        .HasForeignKey(pt => pt.FormId),
                    j =>
                    {
                        j.HasKey(t => new { t.FormId, t.BookId });
                    });

            modelBuilder.Entity<Client>()
                .HasOne(b => b.Form)
                .WithOne(i => i.Client)
                .HasForeignKey<Form>(u => u.ClientId);
        }

        protected void BuildDateFields(ModelBuilder modelBuilder)
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

        protected void BuildDefaultFields(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(entity => entity.Available)
                .HasDefaultValue(0);

            modelBuilder.Entity<Book>()
                .Property(entity => entity.Quantity)
                .HasDefaultValue(0);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=library;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
