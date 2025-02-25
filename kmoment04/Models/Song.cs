using System.ComponentModel.DataAnnotations;
using SongCategoryApi.Models;

namespace SongApi.Models {

    public class Song {

        public int Id {get; set;}

        [Required]
        [StringLength(20, MinimumLength =1, ErrorMessage = "Titel måste vara mellan 1 och 20 bokstäver")]
        public string? Artist {get; set;}

        [Required]
        [StringLength(20, MinimumLength =1, ErrorMessage = "Titel måste vara mellan 1 och 20 bokstäver")]
        public string? Title {get; set;}

        [Required]
        [Range(10, 1000, 
        ErrorMessage = "låten måste vara mellan {11} och {600} sekunder.")]
        public int Length {get; set;}

        public SongCategory? Category {get; set;}

    }
}