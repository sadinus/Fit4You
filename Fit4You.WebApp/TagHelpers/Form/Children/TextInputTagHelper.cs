using Fit4You.WebApp.TagHelpers.Form.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit4You.WebApp.TagHelpers.Form.Children
{
    [HtmlTargetElement("TextInput", ParentTag = "CustomForm")]
    public class TextInputTagHelper : TagHelper
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public string Type { get; set; } = "text";
        public string @Class { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var parentContext = context.Items[typeof(CustomFormTagHelper)] as CustomFormContext;

            output.TagName = "div";
            var classAttribute = String.IsNullOrEmpty(@Class) ? $"form-group {@Class}" : "form-group";
            output.Attributes.SetAttribute("class", classAttribute);
            output.Content.SetHtmlContent(GenerateContent(parentContext, Name, Label, Type, Placeholder, Id));
            base.Process(context, output);
        }

        private string GenerateContent(CustomFormContext context, string name, string label, string type, string placeholder, string id)
        {
            var sb = new StringBuilder();
            var idAttribute = id != null ? id : "";
            var placeholderAttribute = placeholder != null ? $"placeholder='{placeholder}'" : "";
            var classAttribute = !String.IsNullOrEmpty(@Class) ? $"form-control {@Class}" : "form-control";

            var value = context.Model?.GetType()?.GetProperty(name.Substring(0, 1).ToUpperInvariant() + name.Substring(1))?.GetValue(context.Model);
            var valueAttribute = (value != null && type != "password") ? $"value='{value}'" : "";
            sb.Append($"<label for='{name}'>{label}</label>");
            sb.Append($"<input type='{type}' class='{classAttribute}' name='{name}' {valueAttribute} {idAttribute} {placeholderAttribute}>");
            if (context != null && context.ModelState != null && context.ModelState[name] != null && context.ModelState[name].Errors.Count > 0)
            {
                var errors = string.Join(',', context.ModelState[name].Errors.Select(x => x.ErrorMessage));
                sb.Append($"<span data-valmsg-for='{name}' data-valmsg-replace='true' class='field-validation-error text-danger'>{errors}</span>");
            }
            return sb.ToString();
        }
    }
}
