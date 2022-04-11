using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Project2.Mvc.Rendering;

namespace Project2.Mvc.CustomTagHelpers
{
    public class OptionsTagHelper:TagHelper
    {
        public IEnumerable<CustomOptionItem> Items { get; set; }
        public string SelectedValue { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            foreach (var item in Items)
            {
                TagBuilder builder = new TagBuilder("option");
                builder.InnerHtml.Append(item.Text);
                if (SelectedValue == item.Value)
                {
                    builder.Attributes.Add("selected","selected");
                }
                builder.Attributes.Add("value",item.Value);
                builder.Attributes.Add(item.CustomDataKey,item.CustomDataText);
                output.Content.AppendHtml(builder);
            }
        }
    }
}