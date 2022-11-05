using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    internal class FormsRepository : Repository<Form, int>, IFormsRepository
    {
        public FormsRepository(Context context) : base(context, context.Forms)
        {
        }
    }
}
