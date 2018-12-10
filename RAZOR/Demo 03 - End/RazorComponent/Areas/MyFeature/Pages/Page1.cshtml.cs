using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorComponent.MyFeature.Pages
{
    public class Page1Model : PageModel
    {
        public IHttpClientFactory HttpClientFactory { get; }

        public void OnGet()
        {

        }

        public Page1Model(IHttpClientFactory httpClientFactory)
        {
            this.HttpClientFactory = httpClientFactory;
        }
    }
}