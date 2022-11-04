namespace BAL.Mappers
{
    public static class GenresMapper
    {
        public static DAL.Models.Genre<int> ToModel(this DAL.Entities.Genre genre)
        {
            return new DAL.Models.Genre<int>()
            {
                Name = genre.Name,
                Description = genre.Description
            };
        }

        public static DAL.Entities.Genre ToEntity(this DAL.Models.Genre<int> genre)
        {
            return new DAL.Entities.Genre()
            {
                Name = genre.Name,
                Description = genre.Description
            };
        }
    }
}