using System.ComponentModel.DataAnnotations;

namespace ApiPart.Models
{
    public class Categorie
    {
        [Key]
        public int CategId { get; set; }
        [StringLength(100)]
        public string CategName { get; set; } = string.Empty;

        [StringLength(1000)]
        public string CategImg { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Categdes { get; set; } = string.Empty;
    }
}
