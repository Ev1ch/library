namespace PL.Pages
{
    public class Page
    {
        protected string GetCommand()
        {
            Console.Write(">> ");
            return Console.ReadLine();
        }
    }
}
