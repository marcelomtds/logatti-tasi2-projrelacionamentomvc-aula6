using System.Web;
using System.Web.Mvc;

namespace ProjMVCRelacionamento_Aula6
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
