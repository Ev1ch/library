using DAL.Repositories.Abstracts;
using DAL.UnitsOfWork.Abstracts;

namespace DAL.UnitsOfWork
{
    internal class UnitOfWork: IUnitOfWork
    {
        private readonly Context context;

        public IAuthorsRepository AuthorsRepository { get; set; }

        public IBooksRepository BooksRepository { get; set; }

        public IClientsRepository ClientsRepository { get; set; }

        public IGenresRepository GenresRepository { get; set; }

        public UnitOfWork(Context context, IAuthorsRepository authorsRepository, IBooksRepository booksRepository, IClientsRepository clientsRepository, IGenresRepository genresRepository)
        {
            this.context = context;
            AuthorsRepository = authorsRepository;
            BooksRepository = booksRepository;
            ClientsRepository = clientsRepository;
            GenresRepository = genresRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
