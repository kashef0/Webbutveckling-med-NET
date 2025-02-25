using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SongCategoryApi.Models {

    public class SongCategory {

        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        
        [Required]
        [StringLength(20, MinimumLength =1, ErrorMessage = "Titel måste vara mellan 1 och 20 bokstäver")]
        public string? Title {get; set;}

        public string? Description {get; set;}
    }
}