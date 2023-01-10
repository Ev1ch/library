namespace BLL.Exeptions
{
    public class NotValidException : Exception
    {
        public NotValidException(string message) : base(message)
        {
        }
    }
}
