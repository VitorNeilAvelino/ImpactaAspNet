using System.ComponentModel.DataAnnotations;

namespace Marketplace.Identity.Mvc.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string Documento { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}