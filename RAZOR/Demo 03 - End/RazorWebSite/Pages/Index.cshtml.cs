using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorWebSite.Pages
{
    public class IndexModel : PageModel
    {
        public HttpClient Client { get; }

        public async Task OnGet()
        {
            var luke = await GetCharacterAsync("1");
        }

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            this.Client = httpClientFactory.CreateClient("starwars");
        }

        public async Task<Character> GetCharacterAsync(string id)
        {
            var search = $"people/{id}";

            var response = await this.Client.GetAsync(search);
            response.EnsureSuccessStatusCode();

            var characterLists = await response.Content.ReadAsAsync<Character>();

            return characterLists;
        }

    }
}
