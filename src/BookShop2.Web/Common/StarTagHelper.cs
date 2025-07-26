using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;

namespace BookShop2.Web.Common;

[HtmlTargetElement("star")]
public class StarTagHelper : TagHelper
{
    [HtmlAttributeName("avg")]
    public double? Avg { get; set; }
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "mt-3"); // name : value based
        var html = new StringBuilder();
        if (Avg == 0)
        {
            html.Append("<span class=\"text-muted\">No ratings yet</span>");
        }
        else
        {
            double rating = Math.Round(Avg.Value);
            html.Append("<span class=\"text-warning fs-4\">");
            for (int i = 1; i <= 5; i++)
            {
                if (i <= rating)
                {
                    html.Append("<span style='font-size: 2rem; color: gold;'>&#9733;</span>");
                }
                else
                {
                    html.Append("<span style=\"font-size: 2rem; color: lightgray;\">&#9733;</span>");
                }
            }
            html.Append($"<span class='text-dark fs-6'>({Avg.Value.ToString("0.0")})</span>");
            html.Append("</span>");
        }
       output.Content.SetHtmlContent(html.ToString());
    }
}
