using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SubhasishsPieShop.TagHelpers
{
    public class EmailTagHelper:TagHelper
    {
        public string Address { get; set; }
        public string Content { get; set; }
        override public void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Address);
            output.Content.SetContent(Content);
        }
    }
}
