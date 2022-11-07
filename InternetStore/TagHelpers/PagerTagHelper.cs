using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InternetStore.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        public int TotalPages { get; set; } = new();
        public int CurrentPage { get; set; } = new();
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Title { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            
            var content = "";
            for (int i = 1; i <= TotalPages; i++)
            {
                //content = $"{content}<li><a asp-action=\"{Action}\" asp-controller=\"{Controller}\" asp-route-title=\"{Title}\" asp-route-page=\"{i}\">{i}</a></li>";
                content = $"{content}<li><a href=\"/Catalog/{Title}/Page_{i}\">{i}</a></li>";
            }
            output.Content.SetHtmlContent(content);
        }
    }
}
