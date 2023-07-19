using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotesAPI.Models
{
   
    public class Notes
    {
        
        [Key]
        public DateTime dateTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(650)]
        public string Description { get; set; }
    }
}
