using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MichelottiPlaybook
{
    public static class HtmlHelpers
    {
        /// <summary>
        /// This purpose of this method is to ensure ActionLink goes to root Area.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static MvcHtmlString RootActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.AreaActionLink(linkText, actionName, controllerName, areaName: string.Empty);
        }

        public static MvcHtmlString AdminActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            return htmlHelper.AreaActionLink(linkText, actionName, controllerName, areaName: "Admin");
        }

        private static MvcHtmlString AreaActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string areaName)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues: new { area = areaName }, htmlAttributes: null);
        }
        

        public static MvcHtmlString PlayLink(this HtmlHelper htmlHelper, string linkText, string categorySlug, PlayType playType = PlayType.Play)
        {
            var pt = (playType == PlayType.Play ? "Play" : "Drill");
            return htmlHelper.ActionLink(linkText, "Index", "Video", new { categorySlug = categorySlug, playType = pt, area = string.Empty }, null);
        }

        public static MvcHtmlString VideoLink(this HtmlHelper htmlHelper, string linkText, string categorySlug, string videoSlug)
        {
            var playType = PlayType.Drill;
            var pt = (playType == PlayType.Play ? "Play" : "Drill");

            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action("Index", "Video", new { categorySlug = categorySlug, playType = pt }) + "#" + videoSlug;
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", url, linkText));
        }

        public static MvcHtmlString PlayLinkButton(this HtmlHelper htmlHelper, string categorySlug)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            var url = urlHelper.Action("Index", "Video", new { categorySlug = categorySlug, playType = "Play", area = string.Empty });

            var tagBuilder = new TagBuilder("a");
            tagBuilder.MergeAttribute("href", url);
            tagBuilder.MergeAttribute("class", "btn btn-primary");
            tagBuilder.InnerHtml = "View Details &raquo;";

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }

    public enum PlayType
    {
        Play,
        Drill
    }
}