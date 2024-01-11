using System.ComponentModel.DataAnnotations;

namespace EcommerceReact.Models
{
    public class Panier
    {
        [Key]
        public int PanierId { get; set; }

        [Required(ErrorMessage = "Le nom du tapis est requis.")]
        public string? TapisName { get; set; }

        [Required(ErrorMessage = "La taille du tapis est requise.")]
        public string? Size { get; set; }

        [Required(ErrorMessage = "La quantité est requise.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Le prix unitaire est requis.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Le montant total est requis.")]
        public decimal TotalAmount { get; set; }

        // Ajoutez d'autres propriétés du panier au besoin

        // Relation avec le client (si nécessaire)
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
