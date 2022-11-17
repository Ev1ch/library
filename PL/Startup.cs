using PL.Controllers;

namespace PL
{
    public class Startup
    {
        private readonly MainController mainPage;

        public Startup(MainController mainPage)
        {
            this.mainPage = mainPage;
        }

        public void Start()
        {
            mainPage.Init();
        }
    }
}
