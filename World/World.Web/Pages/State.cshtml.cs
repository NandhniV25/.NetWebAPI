using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using World.Web.DTO;

namespace World.Web.Pages
{
    public class StateModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<StateDTO> States { get; set; }

        public void OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("WorldWebAPIs");

            States = httpClient.GetFromJsonAsync<List<StateDTO>>("api/States").Result;

        }
    }
}
