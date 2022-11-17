namespace PL.Controllers
{
    public class Controller
    {
        public string GetCommand()
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }
    }
}
