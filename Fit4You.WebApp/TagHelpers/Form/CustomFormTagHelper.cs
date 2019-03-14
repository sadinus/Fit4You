using Fit4You.WebApp.TagHelpers.Form.Context;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit4You.WebApp.TagHelpers.Form
{
    [HtmlTargetElement("customform")]
    public class CustomFormTagHelper : TagHelper
    {
        [HtmlAttributeName("model")]
        public object Model { get; set; }

        [HtmlAttributeName("modelstate")]
        public ModelStateDictionary ModelState { get; set; }

        [HtmlAttributeName("class")]
        public string @Class { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var customFormContext = new CustomFormContext() { ModelState = ModelState, Model = Model };
            context.Items.Add(typeof(CustomFormTagHelper), customFormContext);

            var childrenContext = await output.GetChildContentAsync();
            var content = new StringBuilder();

            output.TagName = "form";
            var classAttribute = !String.IsNullOrEmpty(@Class) ? $"form-group {@Class}" : "form-group";
            output.Attributes.SetAttribute("class", classAttribute);
            output.Attributes.SetAttribute("method", "post");
            output.Attributes.SetAttribute("enctype", "multipart/form-data");
            content.Append(childrenContext.GetContent());
        }
    }
}
