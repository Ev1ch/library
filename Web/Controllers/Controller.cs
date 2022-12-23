using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Web.Controllers
{
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        public static Exception? GetError(ITempDataDictionary tempData)
        {
            if (!tempData.ContainsKey("Error"))
            {
                return null;
            }

            return new Exception((string)tempData["Error"]);
        }

        protected void SetError(Exception exception)
        {
            TempData["Error"] = exception.Message;
        }
    }
}
