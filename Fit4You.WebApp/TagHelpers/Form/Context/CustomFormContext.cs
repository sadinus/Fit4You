using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4You.WebApp.TagHelpers.Form.Context
{
    public class CustomFormContext
    {
        public object Model { get; set; }
        public ModelStateDictionary ModelState { get; set; }
    }
}
