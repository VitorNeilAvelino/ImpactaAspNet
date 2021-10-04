using System;
using System.ComponentModel.DataAnnotations;

namespace ExpoCenter.Mvc.Models
{
    public class ParticipanteViewModel
    {
        private string cpf;

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11)]
        //[DisplayFormat(DataFormatString = @"{0:000\.000\.000-00}")]
        public string Cpf { get => long.Parse(cpf).ToString(@"000\.000\.000-00"); set => cpf = value; }

        [DataType(DataType.Date)]
        [Display(Name = "Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}