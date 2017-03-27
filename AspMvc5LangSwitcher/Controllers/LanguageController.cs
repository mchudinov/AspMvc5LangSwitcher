using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspMvc5LangSwitcher.Controllers
{
    public class LanguageController : BaseController
    {
        [HttpPost]
        public ActionResult UpdateLanguage(string language)
        {
            string path = Request.UrlReferrer?.AbsolutePath;
            string queryString = Request.UrlReferrer?.Query;
            RouteData routeFromUrl = RouteTable.Routes.GetRouteData(
                new HttpContextWrapper(
                    new HttpContext(
                        new HttpRequest(null, new UriBuilder(Request.Url?.Scheme, Request.Url?.Host, Request.Url.Port, path).ToString(), queryString),
                        new HttpResponse(new System.IO.StringWriter())
                    )
                )
            );
            string controller = routeFromUrl?.Values["controller"].ToString();
            string action = routeFromUrl?.Values["action"].ToString();
            string id = routeFromUrl?.Values["id"].ToString();

            RouteData.Values["id"] = id;
            RouteData.Values["lang"] = language;      

            return RedirectToAction(action, controller, RouteData.Values);
        }
    }
}