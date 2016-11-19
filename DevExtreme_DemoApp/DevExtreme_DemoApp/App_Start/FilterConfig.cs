using System.Web;
using System.Web.Mvc;

namespace DevExtreme_DemoApp {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
