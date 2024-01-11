using System.ComponentModel.DataAnnotations;

namespace EcommerceReact.Models
{
    public class Produit
    {

        [Key]
        public int ProduitId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }

    }
}

