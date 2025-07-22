using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspMvcCoreAppTagHelpersExample
{
    public class EmailTagHelper : TagHelper
    {
        public string? MailTo { get; set; }
        public string? InnerHtml { get; set; }
        public string? DomainName { get; set; }
        public string? TargetAddress { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            if(!String.IsNullOrEmpty(TargetAddress))
            {
                output.Attributes.SetAttribute("href", $"mailto:{ TargetAddress}");
            } else
            {
                output.Attributes.SetAttribute("href", $"mailto:{MailTo}@{DomainName}");
            }
            if(!string.IsNullOrEmpty(InnerHtml))
            {
                output.Content.SetContent(InnerHtml);
            } else if(!string.IsNullOrEmpty(TargetAddress))
            {
                output.Content.SetContent(TargetAddress);
            }
            else
            {
                output.Content.SetContent($"mailto:{MailTo}@{DomainName}");
            }
        }
    }
}
