using PL.Pages;

namespace PL
{
    public class Client
    {
        private readonly MainPage mainPage;

        public Client(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }

        public void Start()
        {
            mainPage.Show();
        }
    }
}
