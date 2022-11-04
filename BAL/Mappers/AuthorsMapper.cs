namespace BAL.Mappers
{
    public static class AuthorsMapper
    {
        public static DAL.Models.Author<int> ToModel(this DAL.Entities.Author author)
        {
            return new DAL.Models.Author<int>()
            {
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
            };
        }

        public static DAL.Entities.Author ToEntity(this DAL.Models.Author<int> author)
        {
            return new DAL.Entities.Author()
            {
                FirstName = author.FirstName,
                MiddleName = author.MiddleName,
                LastName = author.LastName,
            };
        }
    }
}
