using System.Web.Mvc;

namespace AspMvc5LangSwitcher.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}