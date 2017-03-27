using System.Web.Mvc;

namespace AspMvc5LangSwitcher.Controllers
{
    public class DefaultController : BaseController
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}