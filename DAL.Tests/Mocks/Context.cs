using Microsoft.EntityFrameworkCore;

namespace DAL.Tests.Mocks
{
    internal class Context: DAL.Context
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("library");
        }
    }
}