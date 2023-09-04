using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesWeb.DTO;

namespace NotesWeb.Pages
{
    public class NotesByIdDeleteModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotesByIdDeleteModel(IHttpClientFactory httpClientFactory)
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

            var result = httpClient.DeleteAsync($"api/Notes/{Notes.Id}").Result;
            Response.Redirect("/Notes");
        }
    }
}
