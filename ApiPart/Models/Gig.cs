using System.ComponentModel.DataAnnotations;

namespace ApiPart.Models
{
    public class Gig
    {
        [Key]
        public int GigId { get; set; }
        [StringLength(100)]
        public string GigTitle { get; set; } = string.Empty;
        [StringLength(1000)]
        public string GigDisc { get; set; } = string.Empty;
        [StringLength(1000)]
        public string GigDetail { get; set; } = string.Empty;
        [StringLength(1000)]
        public string GigPhoto { get; set; } = string.Empty;

        public int GigPrice { get; set; }

    }
}
