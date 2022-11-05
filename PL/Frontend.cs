using PL.Controllers;

namespace PL
{
    public class Frontend
    {
        private readonly MainController mainPage;

        public Frontend(MainController mainPage)
        {
            this.mainPage = mainPage;
        }

        public void Start()
        {
            mainPage.Init();
        }
    }
}
