using System.ComponentModel.DataAnnotations;

namespace EcommerceReact.Models
{
    public class Client
    {

        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Adress { get; set; }
        public int phoneNumber { get; set; }

    }
}

