using System.Web;
using System.Web.Mvc;

namespace FlashQuiz_2ndAttempt
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}