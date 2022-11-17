using DAL.Repositories.Abstracts;
using DAL.UnitsOfWork.Abstracts;

namespace DAL.UnitsOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly Context context;

        public IAuthorsRepository AuthorsRepository { get; set; }

        public IBooksRepository BooksRepository { get; set; }

        public IClientsRepository ClientsRepository { get; set; }

        public IGenresRepository GenresRepository { get; set; }

        public IFormsRepository FormsRepository { get; set; }

        public UnitOfWork(Context context, IAuthorsRepository authorsRepository, IBooksRepository booksRepository, IClientsRepository clientsRepository, IGenresRepository genresRepository, IFormsRepository formsRepository)
        {
            this.context = context;
            AuthorsRepository = authorsRepository;
            BooksRepository = booksRepository;
            ClientsRepository = clientsRepository;
            GenresRepository = genresRepository;
            FormsRepository = formsRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
