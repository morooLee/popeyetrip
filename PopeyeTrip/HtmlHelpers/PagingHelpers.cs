using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PopEyeTrip.Models;

namespace PopEyeTrip.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int MaxPageNo = 5;
            int MinPage = 0;
            int MaxPage = 0;

            if (pagingInfo.TotalPages > MaxPageNo)
            {
                if ((int)Math.Ceiling((decimal)pagingInfo.CurrentPage / MaxPageNo) == 1)
                {
                    int a = (int)Math.Ceiling((decimal)pagingInfo.CurrentPage / MaxPageNo);
                    MinPage = 1;
                    MaxPage = MaxPageNo;
                }
                else
                {
                    MinPage = ((int)Math.Ceiling((decimal)pagingInfo.CurrentPage / MaxPageNo) - 1) * MaxPageNo + 1;
                    MaxPage = ((int)Math.Ceiling((decimal)pagingInfo.CurrentPage / MaxPageNo) - 1) * MaxPageNo + MaxPageNo;
                }

                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl((pagingInfo.CurrentPage - 1)));
                if (pagingInfo.CurrentPage == 1)
                {
                    tag.MergeAttribute("disabled", "true");
                }
                tag.InnerHtml = "<";
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());

                for (int i = MinPage; i <= MaxPage; i++)
                {
                    if (i <= pagingInfo.TotalPages)
                    {
                        tag = new TagBuilder("a");
                        tag.MergeAttribute("href", pageUrl(i));
                        tag.InnerHtml = i.ToString();

                        if (i == pagingInfo.CurrentPage)
                        {
                            tag.AddCssClass("selected");
                            tag.AddCssClass("btn-primary");
                        }
                        tag.AddCssClass("btn btn-default");
                        result.Append(tag.ToString());
                    }
                }
                tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl((pagingInfo.CurrentPage + 1)));
                if (pagingInfo.CurrentPage == pagingInfo.TotalPages)
                {
                    tag.MergeAttribute("disabled", "true");
                }
                tag.InnerHtml = ">";
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            else
            {
                for (int i = 1; i <= pagingInfo.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.InnerHtml = i.ToString();

                    if (i == pagingInfo.CurrentPage)
                    {
                        tag.AddCssClass("selected");
                        tag.AddCssClass("btn-primary");
                    }
                    tag.AddCssClass("btn btn-default");
                    result.Append(tag.ToString());
                }
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
