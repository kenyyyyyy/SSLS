using SSLS.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            a.InnerHtml = "&laquo;";
            if (pagingInfo.CurrentPage > 1)
            {
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            }
            else
            {
                a.MergeAttribute("href", pageUrl(pagingInfo.TatalPages));
            }
            li.InnerHtml = a.ToString();
            result.Append(li.ToString());
            for (int i = 1; i <= pagingInfo.TatalPages; i++)
            {
                li = new TagBuilder("li");
                a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml = i.ToString();
                li.InnerHtml = a.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    li.AddCssClass("active");
                }
                result.Append(li.ToString());
            }
            li = new TagBuilder("li");
            a = new TagBuilder("a");
            a.InnerHtml = "&raquo;";
            if (pagingInfo.CurrentPage < pagingInfo.TatalPages)
            {
                a.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            }
            else
            {
                a.MergeAttribute("href", pageUrl(1));
            }
            li.InnerHtml = a.ToString();
            result.Append(li.ToString());
            return MvcHtmlString.Create(result.ToString());
        }
    }
}