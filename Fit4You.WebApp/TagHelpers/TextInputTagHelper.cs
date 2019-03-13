using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit4You.WebApp.TagHelpers
{
    [HtmlTargetElement("TextInput")]
    public class TextInputTagHelper : TagHelper
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Type { get; set; } = "text";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "form-group");
            output.Content.SetHtmlContent(GenerateContent(Name, Label, Type, Placeholder, Id));
            base.Process(context, output);
        }

        private string GenerateContent(string name, string label, string type, string placeholder, string id)
        {
            var sb = new StringBuilder();
            var idAttribute = id != null ? id : "";
            var placeholderAttribute = placeholder != null ? $"placeholder=\"{placeholder}\"" : "";

            sb.Append($"<label for=\"{name}\">{label}</label>");
            sb.Append($"<input type=\"{type}\" class=\"form-control\" {idAttribute} {placeholderAttribute}>");
            sb.Append($"<span data-valmsg-for=\"{name}\" data-valmsg-replace=\"true\" class=\"field-validation-error text-danger\"></span>");
            return sb.ToString();
        }
    }
}
