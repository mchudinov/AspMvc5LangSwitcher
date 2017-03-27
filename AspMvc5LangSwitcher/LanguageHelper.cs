using System.Web.Mvc;
using System.Web.Routing;

namespace AspMvc5LangSwitcher
{
    public static class LanguageHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, RouteData routeData, Models.Language language)
        {
            var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                if (routeData.Values["lang"] as string == language.Code)
                {
                    liTagBuilder.AddCssClass("active");
                }
                else
                {
                    routeValueDictionary["lang"] = language.Code;
                }
            }
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(language.Name);
            liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(liTagBuilder.ToString());
        }
    }
}