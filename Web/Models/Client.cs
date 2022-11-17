namespace Web.Models
{
    public class Client : Model<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Form Form { get; set; }
    }
}
