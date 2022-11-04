namespace BAL.Mappers
{
    public static class BooksMapper
    {
        public static DAL.Models.Book<int> ToModel(this DAL.Entities.Book book)
        {
            return new DAL.Models.Book<int>()
            {
                Name = book.Name,
                Description = book.Description,
                Author = book.Author.ToModel()
            };
        }

        public static DAL.Entities.Book ToEntity(this DAL.Models.Book<int> book)
        {
            return new DAL.Entities.Book()
            {
                Name = book.Name,
                Description = book.Description,
                Author = book.Author.ToEntity()
            };
        }
    }
}
