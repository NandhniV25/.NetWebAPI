using System.ComponentModel.DataAnnotations;

namespace NotesAPI.DTO
{
    public class NotesDto
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }
        public NotesDto() 
        {
            DateTime = DateTime.Now;
        }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
