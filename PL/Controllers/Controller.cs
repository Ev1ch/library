namespace PL.Controllers
{
    public class Controller
    {
        protected string GetCommand()
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }
    }
}
