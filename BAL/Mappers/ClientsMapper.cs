namespace BAL.Mappers
{
    public static class ClientsMapper
    {
        public static DAL.Models.Client<int> ToModel(this DAL.Entities.Client client)
        {
            return new DAL.Models.Client<int>()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
            };
        }

        public static DAL.Entities.Client ToEntity(this DAL.Models.Client<int> client)
        {
            return new DAL.Entities.Client()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Phone = client.Phone,
            };
        }
    }
}