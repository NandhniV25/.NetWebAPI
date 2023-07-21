using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesWeb.DTO;

namespace NotesWeb.Pages
{
    public class NotesModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<NotesDto> Notes { get; set; }

        public async void OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("NotesWebAPI");

            Notes = httpClient.GetFromJsonAsync<List<NotesDto>>("api/Notes").Result;

        }
    }
}
