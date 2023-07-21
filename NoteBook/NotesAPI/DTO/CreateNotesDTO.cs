using System.ComponentModel.DataAnnotations;

namespace NotesAPI.DTO
{
    public class CreateNotesDTO
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(650)]
        public string Description { get; set; }
    }
}
