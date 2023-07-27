using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesWeb.DTO;
using System.Net.Http.Json;

namespace NotesWeb.Pages
{
    public class NotesByIdModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotesByIdModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [BindProperty]
        public NotesDto Notes { get; set; }
        public void OnGet(int id)
        {
            if (id == 0)
            {
                Notes = new NotesDto();
            }
            else
            {
                var httpClient = _httpClientFactory.CreateClient("NotesWebAPI");
                Notes = httpClient.GetFromJsonAsync<NotesDto>($"api/Notes/{id}").Result;
            }
        }
        public void OnPost()
        {
            var httpClient = _httpClientFactory.CreateClient("NotesWebAPI");

            var result = httpClient.PutAsJsonAsync<NotesDto>($"api/Notes/{Notes.Id}", Notes).Result;
            Response.Redirect("/Notes");
        }
    }
}
