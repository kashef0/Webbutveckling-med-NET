using System.ComponentModel.DataAnnotations;

namespace KMoment02.Models
{
    public class Products
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        [StringLength(100, ErrorMessage = "Namnet får inte vara längre än 100 tecken.")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pris är obligatoriskt.")]
        [Range(1, 10000, ErrorMessage = "Priset måste vara mellan 1 och 10,000.")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Bild-URL är obligatorisk.")]
        [Url(ErrorMessage = "Ange en giltig URL.")]
        public string imgUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Beskrivning är obligatorisk.")]
        [StringLength(500, ErrorMessage = "Beskrivningen får inte vara längre än 500 tecken.")]
        public string description { get; set; } = string.Empty;
    }
}
