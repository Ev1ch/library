using DAL.Repositories.Abstracts;

namespace DAL.UnitsOfWork.Abstracts
{
    public interface IUnitOfWork
    {
        public IAuthorsRepository AuthorsRepository { get; set; }

        public IBooksRepository BooksRepository { get; set; }

        public IClientsRepository ClientsRepository { get; set; }

        public IGenresRepository GenresRepository { get; set; }

        public void Save();
    }
}